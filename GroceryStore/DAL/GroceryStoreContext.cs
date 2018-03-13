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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
