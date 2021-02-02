using Flunt.Notifications;
using MyStockSys.Domain.Commands;
using MyStockSys.Domain.Interfaces.Command;
using MyStockSys.Domain.Interfaces.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Domain.Queries
{
    public class InventoryControlQueries : Notifiable, ICommandResult
    {
        private readonly IInventoryControlRepository _inventoryControlRepository;
        public InventoryControlQueries(IInventoryControlRepository inventoryControlRepository)
        {
            _inventoryControlRepository = inventoryControlRepository;
        }

        public async Task<ICommandResult> GetAll()
        {
            var listOfInventoryControl = _inventoryControlRepository.List().ToList();

            return listOfInventoryControl != null ? new CommandResult(true, "Dados obtidos com sucesso com sucesso!", listOfInventoryControl) : new CommandResult(false, "Dados não encontrados!", null);
        }

        public async Task<ICommandResult> Get(Guid id)
        {
            var InventoryControl = _inventoryControlRepository.GetById(id);

            return InventoryControl != null ? new CommandResult(true, "Dados obtidos com sucesso com sucesso!", InventoryControl) : new CommandResult(false, "Dados não encontrados!", null);
        }
    }
}
