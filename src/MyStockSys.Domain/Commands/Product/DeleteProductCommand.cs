using Flunt.Notifications;
using Flunt.Validations;
using MyStockSys.Domain.Interfaces.Command;
using System;

namespace MyStockSys.Domain.Commands.Product
{
    public class DeleteProductCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
            );
        }
    }
}
