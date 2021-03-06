﻿using Services.Contacts;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Client.WPF
{
    public partial class UserAddressesWindow : Window
    {
        private IUserService user;
        private IUserContext loggedUser;
        private TextBox addressForm;
        public UserAddressesWindow(IUserService user, IUserContext loggedUser, TextBox addressForm)
        {
            InitializeComponent();
            this.addressForm = addressForm;
            this.user = user;
            this.loggedUser = loggedUser;
            Fillinfo();
        }

        private void Fillinfo()
        {
            var addresses = this.user.GetSpecificUser(loggedUser.LoggedUserId.Value).Adresses.ToList();

            if (addresses.Count > 0)
            {
                this.FirstAddress.Text = addresses[0].AddressText;
                this.Address1.Visibility = Visibility.Visible;
            }
            if (addresses.Count > 1)
            {
                this.SecondAddress.Text = addresses[1].AddressText;
                this.Address2.Visibility = Visibility.Visible;
            }
            if (addresses.Count > 2)
            {
                this.ThirdAddress.Text = addresses[2].AddressText;
                this.Address3.Visibility = Visibility.Visible;
            }
        }

        private void SelectFirstBtn_Click(object sender, RoutedEventArgs e)
        {
            this.addressForm.Text = this.FirstAddress.Text;
            this.Close();
        }

        private void SelectSecondBBtn_Click(object sender, RoutedEventArgs e)
        {
            this.addressForm.Text = this.SecondAddress.Text;
            this.Close();
        }
        private void SelectThirdBtn_Click(object sender, RoutedEventArgs e)
        {
            this.addressForm.Text = this.ThirdAddress.Text;
            this.Close();
        }
    }
}
