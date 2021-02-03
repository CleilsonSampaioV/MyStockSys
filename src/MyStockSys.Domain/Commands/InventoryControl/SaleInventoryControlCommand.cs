using System;
using Flunt.Notifications;
using Flunt.Validations;
using MyStockSys.Domain.Interfaces.Command;

namespace MyStockSys.Domain.Commands.InventoryControl
{
    public class SaleInventoryControlCommand : Notifiable, ICommand
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
