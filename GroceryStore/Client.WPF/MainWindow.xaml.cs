using Autofac;
using Common;
using DAL;
using DAL.Migrations;
using Services.Contacts;
using System.Data.Entity;
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
    }
}