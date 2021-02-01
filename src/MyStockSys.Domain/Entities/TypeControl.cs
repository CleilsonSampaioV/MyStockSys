using System.Collections.Generic;

namespace MyStockSys.Domain.Entities
{
    public class TypeControl : EntityBase
    {
        public string Name { get; set; }
        public virtual IEnumerable<InventoryControl> InventoryControls { get; set; }
    }
}
