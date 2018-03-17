using Autofac;
using Common;
using DAL;
using DAL.Migrations;
using Models;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace Client //Testing Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Init();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.Load("Autofac"));
            var container = builder.Build();

        }
        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GroceryStoreContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }
    }
}
