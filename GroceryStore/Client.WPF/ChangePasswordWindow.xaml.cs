﻿using Models;
using Services.Contacts;
using System.Windows;

namespace Client.WPF
{
    public partial class ChangePasswordWindow : Window
    {
        private readonly IUserService userservice;

        public ChangePasswordWindow(IUserService userservice)
        {
            InitializeComponent();
            this.userservice = userservice;
        }

        private void UpdatePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            var userName = this.UsernameTextBox.Text;
            var oldPassword = this.OldPasswordTextBox.Password;
            var newPassword1 = this.Password1TextBox.Password;
            var newPassword2= this.Password2TextBox.Password;

            var user = this.userservice.GetSpecificUser(userName);

            if (newPassword1 != newPassword2)
            {
                MessageBoxResult result = MessageBox
                    .Show("New passwords don't match! Please try againt!", "", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.Cancel)
                {
                    this.Close();
                }

                this.Password1TextBox.Password = "";
                this.Password2TextBox.Password = "";
            }
            else if ( user == null || user.Password != oldPassword)
            {
                MessageBoxResult result = MessageBox
                    .Show("User not found! Please try again!", "", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.Cancel)
                {
                    this.Close();
                }

                this.UsernameTextBox.Text = "";
                this.OldPasswordTextBox.Password = "";
                this.Password1TextBox.Password = "";
                this.Password2TextBox.Password = "";
            }
            else
            {
                this.userservice.UpdatePassword(user.Id, newPassword1);

                MessageBoxResult result = MessageBox
                    .Show("Password updated successfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }

            }
        }
    }
}