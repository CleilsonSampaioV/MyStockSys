using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using MyStockSys.Domain.Entities;
using System.Linq;

namespace MyStockSys.infra.Data.Repositories.Context
{
    public class MyStockSysContext : DbContext
    {
        public DbSet<InventoryControl> InventoryControls { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SQL5101.site4now.net;Initial Catalog=DB_A6E9D7_MySchoolProject;User Id=DB_A6E9D7_MySchoolProject_admin;Password=senha@senha123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ignorar classes
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyStockSysContext).Assembly);
            MapearPropriedadesEsquecidas(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void MapearPropriedadesEsquecidas(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var property in properties)
                {
                    if (string.IsNullOrEmpty(property.GetColumnType())
                        && !property.GetMaxLength().HasValue)
                    {
                        //property.SetMaxLength(100);
                        property.SetColumnType("VARCHAR(100)");
                    }
                }
            }
        }

    }
}
