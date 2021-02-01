using System;

namespace MyStockSys.Domain.Entities
{
    public class InventoryControl : EntityBase
    {
        public Guid ProductId { get; set; }
        public Guid TypeControlId { get; set; }
        public DateTime DtCreate { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual TypeControl TypeControl { get; set; }

    }
}
