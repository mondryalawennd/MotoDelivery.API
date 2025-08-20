using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MotoDelivery.API;
using MotoDelivery.ORM.Persistence;
using System.Linq;

public class TestWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(Microsoft.AspNetCore.Hosting.IWebHostBuilder builder)
    {
        // Define o ambiente como Test
        builder.UseEnvironment("Test");

        builder.ConfigureServices(services =>
        {
            // Remove DbContext real se existir
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
            if (descriptor != null) services.Remove(descriptor);

            // Adiciona DbContext InMemory
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("MotoDeliveryTestDb");
            });

            // Build ServiceProvider e cria banco
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.EnsureCreated();

            // Popular dados iniciais se necessário
            SeedData(db);
        });
    }

    private void SeedData(AppDbContext db)
    {
        if (!db.Motos.Any())
        {
            db.Motos.Add(new MotoDelivery.Domain.Entities.Moto("moto25", 2023, "Honda", "ABC1234"));
            db.Motos.Add(new MotoDelivery.Domain.Entities.Moto("moto26", 2022, "Yamaha", "XYZ5678"));
        }

        if (!db.Entregador.Any())
        {
            db.Entregador.Add(new MotoDelivery.Domain.Entities.Entregador(
                "entregador01", "Matheus Mota", "68758865000155", Convert.ToDateTime("07/01/1994"), "73815741739", "A"));
        }

        db.SaveChanges();
    }
}
