using DAL.Contracts;
using Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL
{
    public class GroceryStoreContext : DbContext, IGroceryStoreContext
    {
        public GroceryStoreContext()
            : base("GroceryStore")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //// Composite key:
            //modelBuilder.Entity<BankCard>().HasKey(x => new { x.Number, x.ExpirationDate });


            // One-One relation between Inventory and Product
            modelBuilder.Entity<Inventory>().HasRequired(i => i.Product );


            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Address> Addresses { get; set; }
        public virtual IDbSet<BankCard> BankCards { get; set; }
        public virtual IDbSet<Product> Products { get; set; }
        public virtual IDbSet<Order> Orders { get; set; }
        public virtual IDbSet<Inventory> Inventories { get; set; }
    }
}
