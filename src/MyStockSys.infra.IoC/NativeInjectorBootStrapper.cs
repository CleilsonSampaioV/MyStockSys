using Microsoft.Extensions.DependencyInjection;
using MySchool.Domain.Queries;
using MySchool.Infra.Data.Repositories;
using MyStockSys.Domain.Handlers;
using MyStockSys.Domain.Interfaces.Repositories;
using MyStockSys.infra.Data.Repositories.Context;
using MyStockSys.infra.Data.Repositories.Transactions;

namespace MyStockSys.infra.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //// Domain - Commands
            services.AddTransient<InventoryControlQueries>();
            services.AddTransient<ProductQueries>();

            //// Domain - Handlers
            services.AddTransient<ProductHandler, ProductHandler>();
            services.AddTransient<InventoryControlHandler, InventoryControlHandler>();

            //// Infra - Data
            services.AddScoped<IInventoryControlRepository, InventoryControlRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MyStockSysContext>();
        }
    }
}
