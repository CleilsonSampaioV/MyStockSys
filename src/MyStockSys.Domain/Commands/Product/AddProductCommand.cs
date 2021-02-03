using Flunt.Notifications;
using Flunt.Validations;
using MyStockSys.Domain.Interfaces.Command;

namespace MyStockSys.Domain.Commands.Product
{
    public class AddProductCommand : Notifiable, ICommand
    {
        public string Name { get;  set; }
        public decimal Price { get;  set; }
        public string Category { get; set; }
        public int Quantity { get;  set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Name, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Name, 255, "Nome", "Nome deve conter até 255 caracteres")
                .HasMinLen(Category, 1, "Categoria", "Categoria inválida, a categoria só pode ser doce ou salgado")
            );
        }
    }
}
