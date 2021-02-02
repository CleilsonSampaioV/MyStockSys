using MyStockSys.Domain.Entities;
using MyStockSys.Domain.Interfaces.Repositories.Base;
using System;

namespace MyStockSys.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {
    }
}
