using Flunt.Notifications;
using MyStockSys.Domain.Commands;
using MyStockSys.Domain.Interfaces.Command;
using MyStockSys.Domain.Interfaces.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Domain.Queries
{
    public class ProductQueries : Notifiable, ICommandResult
    {
        private readonly IProductRepository _productRepository;
        public ProductQueries(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ICommandResult> GetAll()
        {
            var listOfproducts = _productRepository.List().ToList().OrderBy(x => x.Name);

            return listOfproducts != null ? new CommandResult(true, "Dados obtidos com sucesso com sucesso!", listOfproducts) : new CommandResult(false, "Dados não encontrados!", null);
        }

        public async Task<ICommandResult> Get(Guid id)
        {
            var product = _productRepository.GetById(id);

            return product != null ? new CommandResult(true, "Dados obtidos com sucesso com sucesso!", product) : new CommandResult(false, "Dados não encontrados!", null);
        }
    }
}
