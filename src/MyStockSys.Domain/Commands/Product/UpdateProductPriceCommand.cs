using Flunt.Notifications;
using Flunt.Validations;
using MyStockSys.Domain.Interfaces.Command;
using MyStockSys.Domain.ValueObjects;
using System;

namespace MyStockSys.Domain.Commands.Product
{
    public class UpdateProductPriceCommand : Notifiable, ICommand
    {
        public Guid Id { get; private set; }
        public decimal Percent { get; private set; }
        public TypeOperation TypeOperation { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
            );
        }
    }
}
