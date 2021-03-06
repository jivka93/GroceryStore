﻿using Autofac;
using Common;
using DAL;
using DAL.Migrations;
using Json.Reader;
using Services.Contacts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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

            // From StartUp:
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GroceryStoreContext, Configuration>());

            AutomapperConfiguration.Initialize();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            this.container = builder.Build();

            // Read products from JSON
            if (this.context.Products.Count() == 0)
            {
                ReadJsonFile("C:/Users/Jivka/Desktop/products.json");
            }

            FillCategories();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.Windows.OfType<LoginWindow>().Any())
            {
                var userContext = this.container.Resolve<IUserContext>();
                LoginWindow op = new LoginWindow(userContext, this);
                op.Show();
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var userContext = this.container.Resolve<IUserContext>();
            userContext.Logout();
            var shoppingCart = this.container.Resolve<IShoppingCart>();
            shoppingCart.Clear();
            this.Total.Text = $"{shoppingCart.Total:F2} $";

            DisplayNoLoggedUserView();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.Windows.OfType<RegisterUserWindow>().Any())
            {
                var userservice = this.container.Resolve<IUserService>();
                RegisterUserWindow op = new RegisterUserWindow(userservice);
                op.Show();
            }
        }

        public void DisplayLoggedUserView()
        {
            this.LoginButton.Visibility = Visibility.Hidden;
            this.RegisterButton.Visibility = Visibility.Hidden;
            this.MyProfileButton.Visibility = Visibility.Visible;
            this.LogoutButton.Visibility = Visibility.Visible;
            this.AmountBlock.Visibility = Visibility.Visible;
            var shoppingCart = this.container.Resolve<IShoppingCart>();
            this.AmountBlock.DataContext = shoppingCart;
        }

        private void DisplayNoLoggedUserView()
        {
            this.LoginButton.Visibility = Visibility.Visible;
            this.RegisterButton.Visibility = Visibility.Visible;
            this.MyProfileButton.Visibility = Visibility.Hidden;
            this.LogoutButton.Visibility = Visibility.Hidden;
            this.AmountBlock.Visibility = Visibility.Hidden;
        }

        private void MyProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.Windows.OfType<MyProfile>().Any())
            {
                var userContext = this.container.Resolve<IUserContext>();
                var userservice = this.container.Resolve<IUserService>();
                var addressService = this.container.Resolve<IAddressService>();
                var bankCardService = this.container.Resolve<IBankCardService>();
                var orderServise = this.container.Resolve<IOrderService>();
                var hashing = this.container.Resolve<IHashingPassword>();

                MyProfile op = new MyProfile(userContext, userservice, addressService, orderServise, bankCardService, hashing);
                op.Show();
            }        
        }

        private void ShoppingCartButton_Click(object sender, RoutedEventArgs e)
        {   
            var loggedUser = this.container.Resolve<IUserContext>();

            if (loggedUser.LoggedUserId == null)
            {
                MessageBoxResult result = MessageBox
                    .Show("Please LOGIN first!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var shoppingCart = this.container.Resolve<IShoppingCart>();
                var productService = this.container.Resolve<IProductService>();
                var user = this.container.Resolve<IUserService>();
                var order = this.container.Resolve<IOrderService>();
                var total = this.Total;

                if (!Application.Current.Windows.OfType<ShoppingCartWindow>().Any())
                {
                    ShoppingCartWindow op = new ShoppingCartWindow(shoppingCart, loggedUser, user, productService, order, total);
                    op.Show();
                }
            }
        }

        private void FillCategories()
        {
            var categories = new List<string>() { "All" };         

            var productService = this.container.Resolve<IProductService>();
            var products = productService.GetAll();

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
                var products = productService.SearchByName(searchBar.Text).ToList();
                ProductsContent.ItemsSource = products;
            }
        }

        private void cmbCategories_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var productService = this.container.Resolve<IProductService>();

            if (cmbCategories.SelectedItem.ToString() == "All")
            {
                ProductsContent.ItemsSource = productService.GetAll().ToList();
            }
            else
            {
                var category = this.cmbCategories.SelectedItem.ToString();
                ProductsContent.ItemsSource = productService.SearchByCategory(category).ToList();
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            var loggedUser = this.container.Resolve<IUserContext>();

            if (loggedUser.LoggedUserId == null)
            {
                MessageBoxResult result = MessageBox
                    .Show("Please LOGIN first!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var productName = ((Button)sender).Tag.ToString();
                var productService = container.Resolve<IProductService>();
                var product = productService.SearchByName(productName).FirstOrDefault();
                var shoppingCart = container.Resolve<IShoppingCart>();

                shoppingCart.AddProduct(product);

                RefreshTotal();
            }

        }

        private void RefreshTotal()
        {
            var shoppingCart = container.Resolve<IShoppingCart>();
            this.Total.Text = $"{shoppingCart.Total:F2} $";
        }

        private void ReadJsonFile(string fileLocation)
        {
            var reader = this.container.Resolve<JsonFilesReader>();
            var products = reader.Read(fileLocation);
            var productService = container.Resolve<IProductService>();
            productService.AddProducts(products);
        }
    }
}