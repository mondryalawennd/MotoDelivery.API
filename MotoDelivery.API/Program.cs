using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoDelivery.Application;
using MotoDelivery.Application.Moto.CreateMoto;
using MotoDelivery.Domain.Repositories;
using MotoDelivery.Domain.Services;
using MotoDelivery.ORM.Persistence;
using MotoDelivery.ORM.Repositories;
using MotoDelivery.ORM.Services;
using Serilog;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

namespace MotoDelivery.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Information("Starting web application");


            var isTest = builder.Environment.EnvironmentName == "Test";

            if (!isTest)
            {
                // Apenas em dev/prod
                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(
                        builder.Configuration.GetConnectionString("DBConnection"),
                        b => b.MigrationsAssembly("MotoDelivery.ORM")
                    )
                );
            }

            // MassTransit
            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<Moto2024Consumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("admin");
                        h.Password("admin123");
                    });
                    cfg.ReceiveEndpoint("moto2024-queue", e =>
                    {
                        e.ConfigureConsumer<Moto2024Consumer>(context);
                    });
                });
            });

            // MediatR
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(ApplicationLayer).Assembly, typeof(Program).Assembly);
            });

            // AutoMapper
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(new[] { typeof(Program).Assembly, typeof(ApplicationLayer).Assembly });
            });

            // Injeções de dependência
            builder.Services.AddScoped<IEventoService, EventoService>();
            builder.Services.AddScoped<ILocacaoService, LocacaoService>();
            builder.Services.AddScoped<IMotoRepository, MotoRepository>();
            builder.Services.AddScoped<ILocacaoRepository, LocacaoRepository>();
            builder.Services.AddScoped<IEntregadorRepository, EntregadorRepository>();

            // Configurações de ambiente
            builder.Configuration
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            // Controllers e Swagger
            builder.Services.AddControllers().AddFluentValidation(cfg =>
                 {   cfg.RegisterValidatorsFromAssemblyContaining<ApplicationLayer>();
                     cfg.AutomaticValidationEnabled = true; 
                 });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Moto Delivery.API", Version = "v1", Description = "API para gerenciamento de locação de motos." });
              
            });

            var app = builder.Build();

            
            if (!isTest)
            {
                using var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }

            // Middleware
            if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Docker")
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
