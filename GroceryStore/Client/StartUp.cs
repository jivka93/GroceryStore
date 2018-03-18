﻿using Autofac;
using Common;
using DAL;
using DAL.Migrations;
using Models;
using Services.Contacts;
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
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            
            var userservice = container.Resolve<IUserService>();

            string userName = "gggggggggg";
            string password = "gggggggggg";
            string phoneNumber = "0876488475";
            string firstName = "gggggggggg";
            string lastName = "gggggggggg";

            userservice.RegisterUser(userName, password, phoneNumber, firstName, lastName);

        }
        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GroceryStoreContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }
    }
}
