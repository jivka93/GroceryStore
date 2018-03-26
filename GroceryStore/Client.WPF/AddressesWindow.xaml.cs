using Services.Contacts;
using System.Windows;
using System.Windows.Controls;

namespace Client.WPF
{
    public partial class AddressesWindow : Window
    {
        private readonly IUserContext userContext;
        private readonly IUserService userservice;
        private readonly IAddressService addressService;

        public AddressesWindow(IUserContext userContext, IUserService userservice, IAddressService addressService)
        {
            InitializeComponent();

            this.userContext = userContext;
            this.userservice = userservice;
            this.addressService = addressService;

            FillInfo();
        }

        public void FillInfo()
        {
            int? userId = this.userContext.LoggedUserId;
            if (userId != null)
            {
                int id = (int)userId;
                var userModel = this.userservice.GetSpecificUser(id);
                this.Data.DataContext = userModel;

                if (userModel.Adresses.Count > 2)
                {
                    this.AddNew.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.AddNew.Visibility = Visibility.Visible;
                }

                // Filling:
                this.AddressesContent.ItemsSource = userModel.Adresses;
                this.AddressesContent.DataContext = userModel.Adresses;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int addressId = int.Parse(((Button)sender).Tag.ToString());
            var result = this.addressService.DeleteAddressById(addressId);

            if (result)
            {
                MessageBoxResult message = MessageBox
                    .Show("Address deleted successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);

                FillInfo();
            }
            else
            {
                MessageBoxResult message = MessageBox
                    .Show("Deleting failed!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SaveNewBtn_Click(object sender, RoutedEventArgs e)
        {
            string newAddress = this.NewAddress.Text.Trim();

            if (newAddress == null || newAddress == string.Empty)
            {
                MessageBoxResult message = MessageBox
                    .Show("Invalid address", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                this.addressService.AddNewAddress(newAddress, (int)this.userContext.LoggedUserId);
                MessageBoxResult message = MessageBox
                    .Show("Address is saved successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}
