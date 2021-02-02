using Flunt.Notifications;
using Flunt.Validations;
using MyStockSys.Domain.Interfaces.Command;
using System;

namespace MyStockSys.Domain.Commands.Product
{
    public class UpdateProductNameCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Name, 3, "Nome", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Name, 255, "Nome", "Nome deve conter até 255 caracteres")
            );
        }
    }
}
