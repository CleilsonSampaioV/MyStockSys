using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStockSys.Domain.Entities;
using System;

namespace MyStockSys.infra.Data.Repositories.Map
{
    public class InventoryControlConfigurations : IEntityTypeConfiguration<InventoryControl>
    {
        public void Configure(EntityTypeBuilder<InventoryControl> builder)
        {
            builder.ToTable("InventoryControls");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.DtCreate).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.TypeControl).HasConversion<string>().IsRequired();
        }
    }
}
