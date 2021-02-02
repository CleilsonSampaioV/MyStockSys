using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStockSys.Domain.Entities;

namespace MyStockSys.infra.Data.Repositories.Map
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR(255)").IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.DtCreate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Category).HasConversion<string>().IsRequired();
        }
    }
}
