using Flunt.Notifications;
using System;
using System.Threading.Tasks;
using MyStockSys.Domain.Commands;
using MyStockSys.Domain.Commands.InventoryControl;
using MyStockSys.Domain.Commands.Product;
using MyStockSys.Domain.Entities;
using MyStockSys.Domain.Interfaces.Command;
using MyStockSys.Domain.Interfaces.Handler;
using MyStockSys.Domain.Interfaces.Repositories;
using MyStockSys.Domain.ValueObjects;

namespace MyStockSys.Domain.Handlers
{
    public class InventoryControlHandler : Notifiable, IHandler<AddInventoryControlCommand>
    {
        private readonly IInventoryControlRepository _inventoryControlRepository;
        private readonly IProductRepository _productRepository;
        public InventoryControlHandler(IInventoryControlRepository inventoryControlRepository, IProductRepository productRepository)
        {
            _inventoryControlRepository = inventoryControlRepository;
            _productRepository = productRepository;
        }

        public async Task<ICommandResult> Handle(AddInventoryControlCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", null);
            }

            var produto = _productRepository.GetById(command.ProductId);
            if (produto == null)
            {
                AddNotification("Controle de Inventario.Produto", "Produto não cadastrado.");
            }

            if (command.Quantity <= 0)
            {
                AddNotification("Controle de Inventario.Quantidade", "O valor não pode ser menor de 0");
            }

            // Gerar as Entidades
            var inventoryControl = new InventoryControl(command.ProductId, command.Quantity, command.Operation);

            if (command.Operation == 1)
            {
                produto.IncreaseQuantity(command.Quantity);
            }
            else
            {
                produto.DecreseQuantity(command.Quantity);
            }

            if (produto.Quantity <= 0)
            {
                AddNotification("Controle de Inventario.Quantidade", "A quantidade de produtos requeridos ultrapassa o numero do estoque.");
            }


            // Agrupar as Validações
            AddNotifications(inventoryControl);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da turma", this);

            // Salvar as Informações
            _inventoryControlRepository.Add(inventoryControl);
            _productRepository.Edit(produto);

            // Retornar informações
            return new CommandResult(true, "Cadastro realizado com sucesso!", inventoryControl);
        }
    }
}
