using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IEfUnitOfWork
    {
        IEfGenericRepository<User> Users { get; }
        IEfGenericRepository<Address> Addresses { get; }
        IEfGenericRepository<BankCard> BankCards { get;}
        IEfGenericRepository<Inventory> Inventories { get; }
        IEfGenericRepository<Order> Orders { get; }
        IEfGenericRepository<Product> Products { get; }
        void SaveChanges();
        void Dispose();
    }
}
