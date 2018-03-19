using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        protected readonly IGroceryStoreContext dbContext;

        public EfUnitOfWork(IGroceryStoreContext context)
        {
            this.dbContext = context;
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}
