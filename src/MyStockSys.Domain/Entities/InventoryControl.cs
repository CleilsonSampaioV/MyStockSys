using MyStockSys.Domain.ValueObjects;
using System;

namespace MyStockSys.Domain.Entities
{
    public class InventoryControl : EntityBase
    {
        public Guid ProductId { get; set; }
        public DateTime DtCreate { get; set; }
        public int Quantity { get; set; }
        public int TypeControl { get; set; }

        public InventoryControl(Guid productId,int quantity, int typeControl)
        {
            ProductId = productId;
            Quantity = quantity;
            TypeControl = typeControl;
        }
    }
}
