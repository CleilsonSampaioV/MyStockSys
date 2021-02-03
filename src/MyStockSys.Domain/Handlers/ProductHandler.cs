using Flunt.Notifications;
using MyStockSys.Domain.Commands;
using MyStockSys.Domain.Commands.Product;
using MyStockSys.Domain.Entities;
using MyStockSys.Domain.Interfaces.Command;
using MyStockSys.Domain.Interfaces.Handler;
using MyStockSys.Domain.Interfaces.Repositories;
using MyStockSys.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace MyStockSys.Domain.Handlers
{
    public class ProductHandler : Notifiable,
        IHandler<AddProductCommand>,
        IHandler<UpdateProductNameCommand>,
        IHandler<UpdateProductPriceCommand>,
         IHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public ProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ICommandResult> Handle(AddProductCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", null);
            }

            // Verificar se a entidade já está cadastrado
            if (_productRepository.Exist(x => x.Name == command.Name))
                AddNotification("Produto", "Já existe um produto cadastrada com esse nome");

            if (command.Quantity <= 0)
            {
                AddNotification("Produto.Quantidade", "Para inserir um produto a quantidade inicial deve ser maior que 0");
            }

            var product = new Product(command.Name, command.Price, command.Quantity);

            product.Category = command.Category == "Doce" ? Category.Candy : Category.Savory;

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Escola", this);

            // Salvar as Informações
            _productRepository.Add(product);

            // Retornar informações
            return new CommandResult(true, "Cadastro realizado com sucesso!", product);
        }

        public async Task<ICommandResult> Handle(UpdateProductNameCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", null);
            }

            var product = _productRepository.GetById(command.Id);

            if (product == null)
            {
                AddNotification("Produto", "Produto não cadastrada");
            }

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Escola", this);

            // Salvar as Informações
            _productRepository.Edit(product);

            // Retornar informações
            return new CommandResult(true, "Alteração realizada com sucesso!", product);
        }

        public async Task<ICommandResult> Handle(UpdateProductPriceCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", this);
            }

            var product = _productRepository.GetById(command.Id);

            // Verificar se Documento já está cadastrado
            if (product == null)
            {
                AddNotification("Produto", "Produto não cadastrado");
                return new CommandResult(false, "Produto não cadastrado.", null);
            }

            if (command.TypeOperation == TypeOperation.Acrescimo)
            {
                product.SetIncreasePrice(command.Percent);
            }
            else
            {
                product.SetDiscontPrice(command.Percent);
            }

            if (product.Price <= 0)
            {
                AddNotification("Produto.Preço","O valor da porcentagem gerou um valor de produto 0");
            }

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar a alteração do preço", this);

            // Salvar as Informações
            _productRepository.Edit(product);

            // Retornar informações
            return new CommandResult(true, "Alteração realizada com sucesso!", product);
        }

        public async Task<ICommandResult> Handle(DeleteProductCommand command)
        {
            // Validar ID
            if (command.Id == Guid.Empty)
            {
                AddNotification("Id", "Parametro inválido.");
            }

            var product = _productRepository.GetById(command.Id);

            // Verificar se Escola já está cadastrado
            if (product == null)
            {
                AddNotification("Produto", "Produto não cadastrada");
                return new CommandResult(false, "Dados de entrada in válidos.", this);
            }

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Escola", this);

            // Escluindo a escola
            _productRepository.Remove(product);

            // Retornar informações
            return new CommandResult(true, "Exclusão realizada com sucesso!", null);
        }
    }
}
