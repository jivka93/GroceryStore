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
using System.Windows.Input;

namespace Client.WPF
{
    public partial class MainWindow : Window
    {
        private IComponentContext container;
        private GroceryStoreContext context;

        public MainWindow()
        {
            InitializeComponent();

            this.context = new GroceryStoreContext();

            FillCategories();

            // From StartUp:
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GroceryStoreContext, Configuration>());
            AutomapperConfiguration.Initialize();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            this.container = builder.Build();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var userContext = this.container.Resolve<IUserContext>();
            LoginWindow op = new LoginWindow(userContext, this);
            op.Show();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var userContext = this.container.Resolve<IUserContext>();
            userContext.Logout();
            DisplayNoLoggedUserView();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var userservice = this.container.Resolve<IUserService>();
            RegisterUserWindow op = new RegisterUserWindow(userservice);
            op.Show();
        }

        public void DisplayLoggedUserView()
        {
            this.LoginButton.Visibility = Visibility.Hidden;
            this.RegisterButton.Visibility = Visibility.Hidden;
            this.MyProfileButton.Visibility = Visibility.Visible;
            this.LogoutButton.Visibility = Visibility.Visible;
        }

        private void DisplayNoLoggedUserView()
        {
            this.LoginButton.Visibility = Visibility.Visible;
            this.RegisterButton.Visibility = Visibility.Visible;
            this.MyProfileButton.Visibility = Visibility.Hidden;
            this.LogoutButton.Visibility = Visibility.Hidden;
        }

        private void MyProfileButton_Click(object sender, RoutedEventArgs e)
        {
            var userContext = this.container.Resolve<IUserContext>();
            var userservice = this.container.Resolve<IUserService>();
            MyProfile op = new MyProfile(userContext, userservice);
            op.Show();
            
        }

        private void ShoppingCartButton_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCartWindow op = new ShoppingCartWindow();
            op.Show();
        }

        private void FillCategories()
        {
            var categories = new List<string>() { "All" };         
            List<Product> products = this.context.Products.ToList();

            foreach (var product in products)
            {
                if (!categories.Contains(product.Category))
                {
                    categories.Add(product.Category);
                }
            }
            cmbCategories.ItemsSource = categories;
        }


        private void SearchBar_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var productService = this.container.Resolve<IProductService>();
                var products = productService.SearchByName(searchBar.Text);
                foreach (var item in products)
                {
                    this.Title = item.Price.ToString();
                }
            }
        }

        private void cmbCategories_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cmbCategories.SelectedItem.ToString() == "All")
            {
                ProductsContent.ItemsSource = this.context.Products.ToList();
            }
            else
            {
                var category = this.cmbCategories.SelectedItem.ToString();
                ProductsContent.ItemsSource = this.context.Products.Where(p => p.Category == category).ToList();
            }
        }



    }
}