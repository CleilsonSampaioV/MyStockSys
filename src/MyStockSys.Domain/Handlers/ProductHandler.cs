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

            if (command.Category == "Doce")
            {
                product.Category = Category.Candy;
            }
            else
            {
                product.Category = Category.Savory;
            }

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

            var school = _productRepository.GetById(command.Id);

            // Verificar se Documento já está cadastrado
            if (school == null)
            {
                AddNotification("Escola", "Escola não cadastrada");
            }



            // Agrupar as Validações
            AddNotifications(school);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Escola", this);

            // Salvar as Informações
            _productRepository.Edit(school);

            // Retornar informações
            return new CommandResult(true, "Alteração realizada com sucesso!", school);
        }

        public async Task<ICommandResult> Handle(UpdateProductPriceCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", this);
            }

            var school = _productRepository.GetById(command.Id);

            // Verificar se Documento já está cadastrado
            if (school == null)
            {
                AddNotification("Escola", "Escola não cadastrada");
            }

            // Agrupar as Validações
            AddNotifications(school);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Escola", this);

            // Salvar as Informações
            _productRepository.Edit(school);

            // Retornar informações
            return new CommandResult(true, "Alteração realizada com sucesso!", school);
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
