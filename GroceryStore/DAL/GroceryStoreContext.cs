using Models;
using System.Data.Entity;

namespace DAL
{
    public class GroceryStoreContext : DbContext
    {
        public GroceryStoreContext()
            : base("GroceryStore")
        {

        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }
}
