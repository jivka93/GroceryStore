using DAL.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        protected readonly GroceryStoreContext dbContext;

        public EfUnitOfWork(GroceryStoreContext context)
        {
            Users = new EfGenericRepository<User>(context);
            Addresses = new EfGenericRepository<Address>(context);
            BankCards = new EfGenericRepository<BankCard>(context);
            Inventories = new EfGenericRepository<Inventory>(context);
            Orders = new EfGenericRepository<Order>(context);
            Products = new EfGenericRepository<Product>(context);
            this.dbContext = context;
        }
        public IEfGenericRepository<User> Users { get; private set; }
        public IEfGenericRepository<Address> Addresses{ get; private set; }
        public IEfGenericRepository<BankCard> BankCards { get; private set; }
        public IEfGenericRepository<Inventory> Inventories { get; private set; }
        public IEfGenericRepository<Order> Orders { get; private set; }
        public IEfGenericRepository<Product> Products { get; private set; }


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
