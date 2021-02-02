using MyStockSys.Domain.Entities;
using MyStockSys.Domain.Interfaces.Repositories;
using MyStockSys.infra.Data.Repositories.Base;
using MyStockSys.infra.Data.Repositories.Context;
using System;

namespace MySchool.Infra.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product, Guid>, IProductRepository
    {
        private readonly MyStockSysContext _myStockSysContext;
        public ProductRepository(MyStockSysContext myStockSysContext) : base(myStockSysContext)
        {
            _myStockSysContext = myStockSysContext;
        }
    }
}
