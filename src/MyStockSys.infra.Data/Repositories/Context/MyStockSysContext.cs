using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace MyStockSys.infra.Data.Repositories.Context
{
    public class MyStockSysContext : DbContext
    {
        //public DbSet<School> School { get; set; }
        //public DbSet<Class> Class { get; set; }

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

            ////aplicar configurações
            //modelBuilder.ApplyConfiguration(new MapSchool());
            //modelBuilder.ApplyConfiguration(new MapClass());

            base.OnModelCreating(modelBuilder);
        }
    }
}
