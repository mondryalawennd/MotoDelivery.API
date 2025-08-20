using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MotoDelivery.Domain.Entities;
using MotoDelivery.ORM.Mapping;
using System.Reflection;

namespace MotoDelivery.ORM.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Locacao> Locacao { get; set; }
        public DbSet<Entregador> Entregador { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MotoConfiguration());
            modelBuilder.ApplyConfiguration(new LocacaoConfiguration());
            modelBuilder.ApplyConfiguration(new EntregadorConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public class DefaultContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<AppDbContext>();
                var connectionString = configuration.GetConnectionString("DBConnection");

                builder.UseNpgsql(
                    connectionString,
                    b => b.MigrationsAssembly("MotoDelivery.ORM")
                );

                return new AppDbContext(builder.Options);
            }
        }
    }
}