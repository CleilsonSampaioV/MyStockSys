﻿using System;
using Flunt.Notifications;
using Flunt.Validations;
using MyStockSys.Domain.Interfaces.Command;

namespace MyStockSys.Domain.Commands.InventoryControl
{
    public class AddInventoryControlCommand : Notifiable, ICommand
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int Operation { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
            );
        }
    }
}
