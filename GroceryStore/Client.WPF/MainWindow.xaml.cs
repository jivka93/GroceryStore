using Autofac;
using Common;
using DAL;
using DAL.Migrations;
using Models;
using Services;
using Services.Contacts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Client.WPF
{
    public partial class MainWindow : Window
    {
        private IComponentContext container;

        public MainWindow()
        {
            InitializeComponent();

            FillCategories();

            // From StartUp:
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GroceryStoreContext, Configuration>());
            AutomapperConfiguration.Initialize();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            // it's here because it doesn't work inside the module
            builder.RegisterType<UserContext>().As<IUserContext>().SingleInstance();
            this.container = builder.Build();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var userContext = this.container.Resolve<IUserContext>();
            LoginWindow op = new LoginWindow(userContext);
            op.Show();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var userservice = this.container.Resolve<IUserService>();
            RegisterUserWindow op = new RegisterUserWindow(userservice);
            op.Show();
        }

        private void ShoppingCartButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FillCategories()
        {
            // Finding all categories from database
            var categories = new List<string>() { "All" };

            var context = new GroceryStoreContext();
            List<Product> products = context.Products.ToList();

            foreach (var product in products)
            {
                if (!categories.Contains(product.Category))
                {
                    categories.Add(product.Category);
                }
            }

            //var c = (context.Products.SelectMany(x => x.Category).Distinct()).ToList();


            // Filling the comboBox content
            cmbCategories.ItemsSource = categories;
        }
    }
}