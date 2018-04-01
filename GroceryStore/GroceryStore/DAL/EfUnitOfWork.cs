using DAL.Contracts;

namespace DAL
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        protected readonly GroceryStoreContext dbContext;

        public EfUnitOfWork(GroceryStoreContext context)
        {
            this.dbContext = context;
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
