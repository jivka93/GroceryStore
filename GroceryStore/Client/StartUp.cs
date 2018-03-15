using DAL;
using DAL.Migrations;
using Models;
using System.Data.Entity;
using System.Linq;

namespace Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GroceryStoreContext, Configuration>());

            var ctx = new GroceryStoreContext();

            //ctx.Set<User>().Where(x => x.FirstName == "Jivka")
            //    .FirstOrDefault().Adresses
            //    .Add(new Address() { AddressText = "Sofia, Studentski Grad 9" });


        }
    }
}
