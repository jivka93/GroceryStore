using Autofac;
using Common;
using DAL;
using DAL.Migrations;
using Services.Contacts;
using System;
using System.Data.Entity;
using System.Globalization;
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
            var userName = this.UsernameTextBox.Text.Trim();
            var password = this.PasswordTextBox.Password.Trim();
            var phoneNumber = this.PhoneTextBox.Text.Trim();
            var firstName = this.FirstnameTextBox.Text.Trim();
            var lastName = this.LastnameTextBox.Text.Trim();
            var address = this.AddressTextBox.Text.Trim();
            var cardNumber = this.CardNumberTextBox.Text.Trim();
            DateTime? expDate = DateTime.ParseExact(this.ExpDateTextBox.Text.Trim(),"MM-yyyy", CultureInfo.InvariantCulture);
            var cardName = this.CardNameTextBox.Text.Trim();

            bool result = this.userservice.RegisterUser(userName,password,phoneNumber, 
                firstName, 
                lastName,
                address,
                cardNumber,
                expDate,
                cardName);

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
                    .Show("Invalid information!", "", MessageBoxButton.OK, MessageBoxImage.Information);

                if (popup == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }

            this.Close();
        }
    }
}
