namespace MyStockSys.infra.Data.Repositories.Transactions
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
