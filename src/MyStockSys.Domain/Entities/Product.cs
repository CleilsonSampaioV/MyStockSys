using System;

namespace MyStockSys.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product(string name, decimal price, DateTime dtCreate, int quantity)
        {
            Name = name;
            if (string.IsNullOrEmpty(Name))
            {
                AddNotification("Produto", "Informe um nome para o produto");
            }

            Price = price;
            if (Price == 0)
            {
                AddNotification("Produto.Preço", "Informe um valor válido para a produto");
            }

            DtCreate = dtCreate;
            if (DtCreate == null || dtCreate == new DateTime())
            {
                AddNotification("Produto.DataCadastro", "Informe uma data válida para a produto");
            }


            Quantity = quantity;
            if (Quantity <= 0)
            {
                AddNotification("Produto.Quantidade", "Informe uma quantidade válida para a produto");
            }

        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public DateTime DtCreate { get; private set; }
        public int Quantity { get; private set; }
        public Category Category { get; set; }
    }
}
