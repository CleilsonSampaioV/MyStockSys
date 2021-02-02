using Flunt.Notifications;
using Flunt.Validations;
using MyStockSys.Domain.Interfaces.Command;
using System;

namespace MyStockSys.Domain.Commands.Product
{
    public class AddInventoryControlCommand : Notifiable, ICommand
    {
        public Guid ProductId { get; set; }
        public Guid TypeControlId { get; set; }
        public int Quantity { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
            );
        }
    }
}
