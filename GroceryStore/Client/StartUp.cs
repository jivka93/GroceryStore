using DAL;
using System.Data.Entity;
using System.Linq;

namespace Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<GroceryStoreContext, Configuration>());

            var ctx = new GroceryStoreContext();

            System.Console.WriteLine(ctx.Users.Count());

            ctx.SaveChanges();
        }
    }
}
