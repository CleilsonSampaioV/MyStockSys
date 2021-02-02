using MyStockSys.Domain.ValueObjects;
using System;

namespace MyStockSys.Domain.Entities
{
    public class InventoryControl : EntityBase
    {
        public Guid ProductId { get; set; }
        public DateTime DtCreate { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public TypeControl TypeControl { get; set; }
    }
}
