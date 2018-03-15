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
            // Composite key:
            modelBuilder.Entity<BankCard>().HasKey(x => new { x.Number, x.ExpirationDate });
            // One-One relation between Inventory and Product
            modelBuilder.Entity<Inventory>().HasRequired(i => i.Product );


            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<BankCard> BankCards { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
    }
}
