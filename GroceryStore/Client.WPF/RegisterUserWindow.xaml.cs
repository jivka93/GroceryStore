using Autofac;
using Common;
using DAL;
using DAL.Migrations;
using DTO;
using Services;
using Services.Contacts;
using System.Data.Entity;
using System.Reflection;
using System.Windows;

namespace Client.WPF
{
    /// <summary>
    /// Interaction logic for RegisterUserWindow.xaml
    /// </summary>
    public partial class RegisterUserWindow : Window
    {
        private IComponentContext container;

        public RegisterUserWindow()
        {
            InitializeComponent();


            // From StartUp:
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GroceryStoreContext, Configuration>());
            AutomapperConfiguration.Initialize();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            this.container = builder.Build();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            //todo validation
            var userName = this.UsernameTextBox.Text;
            var password = this.PasswordTextBox.Text;
            var phoneNumber = this.PhoneTextBox.Text;
            var firstName = this.FirstnameTextBox.Text;
            var lastName = this.LastnameTextBox.Text;

            var userservice = this.container.Resolve<IUserService>();

            userservice.RegisterUser(userName,password,phoneNumber, firstName, lastName);
        }
    }
}
