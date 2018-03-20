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
    public partial class RegisterUserWindow : Window
    {
        private readonly IUserService userservice;

        public RegisterUserWindow(IUserService userservice)
        {
            InitializeComponent();
            this.userservice = userservice;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            //todo validation
            var userName = this.UsernameTextBox.Text;
            var password = this.PasswordTextBox.Password;
            var phoneNumber = this.PhoneTextBox.Text;
            var firstName = this.FirstnameTextBox.Text;
            var lastName = this.LastnameTextBox.Text;

            bool result = this.userservice.RegisterUser(userName,password,phoneNumber, firstName, lastName);

            if (result)
            {
                MessageBoxResult popup = MessageBox
                    .Show("Registered successfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);

                if (popup == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBoxResult popup = MessageBox
                    .Show("Error!", "", MessageBoxButton.OK, MessageBoxImage.Information);

                if (popup == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }

            this.Close();
        }
    }
}
