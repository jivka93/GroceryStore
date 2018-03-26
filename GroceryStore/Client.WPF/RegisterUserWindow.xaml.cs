using Services.Contacts;
using System;
using System.Globalization;
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
            // Reading the user input:
            var userName = this.UsernameTextBox.Text.Trim();
            var password = this.PasswordTextBox.Password.Trim();
            var phoneNumber = this.PhoneTextBox.Text.Trim();
            var firstName = this.FirstnameTextBox.Text.Trim();
            var lastName = this.LastnameTextBox.Text.Trim();
            var address = this.AddressTextBox.Text.Trim();
            var cardNumber = this.CardNumberTextBox.Text.Trim();
            DateTime? expDate = null;
            if (this.ExpDateTextBox.Text.Trim() != string.Empty)
            {
                try
                {
                    expDate = DateTime.ParseExact(this.ExpDateTextBox.Text.Trim(), "MM-yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    MessageBoxResult op = MessageBox
                        .Show("Invalid date format!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            var cardName = this.CardNameTextBox.Text.Trim();

            // Validations:
            if (userName == null || userName.Length < 5 || userName.Length > 15 ||
                password == null || password.Length < 5 || password.Length > 15 ||
                phoneNumber == null || phoneNumber.Length < 5 || phoneNumber.Length > 15 )
            {
                MessageBoxResult op = MessageBox
                    .Show("Required: username[5-15], password[5-15], phone[5-15]", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

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
