using MyStockSys.Domain.Entities;
using MyStockSys.Domain.Interfaces.Repositories;
using MyStockSys.infra.Data.Repositories.Base;
using MyStockSys.infra.Data.Repositories.Context;
using System;

namespace MySchool.Infra.Data.Repositories
{
    public class InventoryControlRepository : RepositoryBase<InventoryControl, Guid>, IInventoryControlRepository
    {
        private readonly MyStockSysContext _myStockSysContext;
        public InventoryControlRepository(MyStockSysContext myStockSysContext) : base(myStockSysContext)
        {
            _myStockSysContext = myStockSysContext;
        }
    }
}
