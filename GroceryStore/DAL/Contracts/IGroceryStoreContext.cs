using Models;
using System.Data.Entity;

namespace DAL.Contracts
{
    interface IGroceryStoreContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<Address> Addresses { get; set; }
        IDbSet<BankCard> BankCards { get; set; }
        IDbSet<Product> Products { get; set; }
        IDbSet<Order> Orders { get; set; }
        IDbSet<Inventory> Inventories { get; set; }
    }
}
