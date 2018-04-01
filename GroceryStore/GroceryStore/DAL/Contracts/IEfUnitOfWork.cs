namespace DAL.Contracts
{
    public interface IEfUnitOfWork
    {
        void SaveChanges();
        void Dispose();
    }
}
