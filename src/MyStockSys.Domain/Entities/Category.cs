using System;
using System.Collections.Generic;

namespace MyStockSys.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public Guid ProductId { get; set; }
        public virtual IEnumerable<Product> MyProperty { get; set; }
    }
}
