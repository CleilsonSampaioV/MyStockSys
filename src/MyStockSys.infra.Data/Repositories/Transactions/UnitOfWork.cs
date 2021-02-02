using MyStockSys.infra.Data.Repositories.Context;

namespace MyStockSys.infra.Data.Repositories.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyStockSysContext _myStockSysContext;

        public UnitOfWork(MyStockSysContext myStockSysContext)
        {
            _myStockSysContext = myStockSysContext;
        }

        public void SaveChanges()
        {
            _myStockSysContext.SaveChanges();
        }
    }
}


