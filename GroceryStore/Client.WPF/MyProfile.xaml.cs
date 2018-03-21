using Services.Contacts;
using System.Windows;

namespace Client.WPF
{
    public partial class MyProfile : Window
    {
        private readonly IUserContext userContext;
        private readonly IUserService userservice;


        public MyProfile(IUserContext userContext, IUserService userservice)
        {
            InitializeComponent();

            this.userContext = userContext;
            this.userservice = userservice;

            

            FillUserInfo();
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow op = new ChangePasswordWindow(this.userservice);
            op.Show();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FillUserInfo()
        {
            int? userId = this.userContext.LoggedUserId;
            if (userId != null)
            {
                int id = (int)userId;
                var userModel = this.userservice.GetSpecificUser(id);

                // Filling:
                this.UsernameText.Text = userModel.Username;
                this.FirstNameText.Text = userModel.FirstName;
                this.LastNameText.Text = userModel.LastName;
                this.PhoneText.Text = userModel.PhoneNumber;

                this.AddressesContent.ItemsSource = userModel.Adresses;
                this.BankCardsContent.ItemsSource = userModel.BankCards;
            }
        }
    }
}
