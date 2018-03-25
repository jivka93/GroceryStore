using Models;
using Services.Contacts;
using System.Windows;

namespace Client.WPF
{
    public partial class AddressesWindow : Window
    {
        private readonly IUserContext userContext;
        private readonly IUserService userservice;

        public AddressesWindow(IUserContext userContext, IUserService userservice)
        {
            InitializeComponent();

            this.userContext = userContext;
            this.userservice = userservice;
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

                // Filling:
                this.AddressesContent.ItemsSource = userModel.Adresses;
                this.AddressesContent.DataContext = userModel.Adresses;
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveNewBtn_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
