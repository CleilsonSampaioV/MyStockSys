using Microsoft.Extensions.DependencyInjection;
using MySchool.Infra.Data.Repositories;
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
            //services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, bool>, CustomerCommandHandler>();
            //services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
            //services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

            //// Infra - Data
            services.AddScoped<IInventoryControlRepository, InventoryControlRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MyStockSysContext>();
        }
    }
}
