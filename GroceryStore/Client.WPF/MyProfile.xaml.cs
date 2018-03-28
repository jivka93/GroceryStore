using iTextSharp.text;
using iTextSharp.text.pdf;
using Services.Contacts;
using System.IO;
using System.Windows;


namespace Client.WPF
{
    public partial class MyProfile : Window
    {
        private readonly IUserContext userContext;
        private readonly IUserService userservice;
        private readonly IAddressService addressService;
        private readonly IBankCardService bankCardService;
        private readonly IOrderService orderServise;

        public MyProfile(IUserContext userContext, IUserService userservice, IAddressService addressService, IOrderService orderServise, IBankCardService bankCardService)
        {
            InitializeComponent();

            this.userContext = userContext;
            this.userservice = userservice;
            this.addressService = addressService;
            this.orderServise = orderServise;
            this.bankCardService = bankCardService;

            FillUserInfo();
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow op = new ChangePasswordWindow(this.userservice);
            op.Show();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            this.FirstNameText.Visibility = Visibility.Collapsed;
            this.NewFirstNameText.Visibility = Visibility.Visible;

            this.LastNameText.Visibility = Visibility.Collapsed;
            this.NewLastNameText.Visibility = Visibility.Visible;

            this.PhoneText.Visibility = Visibility.Collapsed;
            this.NewPhoneText.Visibility = Visibility.Visible;

            this.UpdateButton.Visibility = Visibility.Collapsed;
            this.ChangePasswordButton.Visibility = Visibility.Collapsed;
            this.SaveChangesButton.Visibility = Visibility.Visible;
        }

        private void FillUserInfo()
        {
            int? userId = this.userContext.LoggedUserId;
            if (userId != null)
            {
                int id = (int)userId;
                var userModel = this.userservice.GetSpecificUser(id);
                this.Data.DataContext = userModel;

                // Filling:
                this.UsernameText.Text = userModel.Username;
                this.FirstNameText.Text = userModel.FirstName;
                this.LastNameText.Text = userModel.LastName;
                this.PhoneText.Text = userModel.PhoneNumber;

                this.AddressesContent.ItemsSource = userModel.Adresses;
                this.BankCardsContent.ItemsSource = userModel.BankCards;
            }
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            string newFirstName = this.NewFirstNameText.Text.Trim();
            string newLastName = this.NewLastNameText.Text.Trim();
            string newPhone = this.NewPhoneText.Text.Trim();

            if (newFirstName != null && newFirstName != string.Empty && newFirstName.Length > 20)
            {
                MessageBoxResult err1 = MessageBox
                    .Show("First name must be no more than 20 symbols!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NewFirstNameText.Text = "";
                this.NewLastNameText.Text = "";
                this.NewPhoneText.Text = "";
            }
            else if (newLastName != null && newLastName != string.Empty && newLastName.Length > 20)
            {
                MessageBoxResult err2 = MessageBox
                    .Show("Last name must be no more than 20 symbols!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NewFirstNameText.Text = "";
                this.NewLastNameText.Text = "";
                this.NewPhoneText.Text = "";
            }
            else if (newPhone != null && newPhone != string.Empty && newPhone.Length < 5 || newPhone.Length > 15)
            {
                MessageBoxResult err3 = MessageBox
                    .Show("Phone must be no less then 5 symbols and no more than 20 symbols!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NewFirstNameText.Text = "";
                this.NewLastNameText.Text = "";
                this.NewPhoneText.Text = "";
            }
            else
            {
                var user = this.userservice.GetSpecificUser((int)(this.userContext.LoggedUserId));
                this.userservice.UpdateProfileInfo(user.Id, newFirstName, newLastName, newPhone);

                this.NewFirstNameText.Visibility = Visibility.Collapsed;
                this.FirstNameText.Visibility = Visibility.Visible;

                this.NewLastNameText.Visibility = Visibility.Collapsed;
                this.LastNameText.Visibility = Visibility.Visible;

                this.NewPhoneText.Visibility = Visibility.Collapsed;
                this.PhoneText.Visibility = Visibility.Visible;

                this.SaveChangesButton.Visibility = Visibility.Collapsed;
                this.UpdateButton.Visibility = Visibility.Visible;
                this.ChangePasswordButton.Visibility = Visibility.Visible;

                FillUserInfo();

                MessageBoxResult result = MessageBox
                    .Show("Info updated successfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        

        private void UpdateAddressesBtn_Click(object sender, RoutedEventArgs e)
        {
            AddressesWindow op = new AddressesWindow(this.userContext, this.userservice, this.addressService);
            op.Show();
        }

        private void UpdateCardsBtn_Click(object sender, RoutedEventArgs e)
        {
            BankCardsWindow op = new BankCardsWindow(this.userContext, this.userservice, this.bankCardService);
            op.Show();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrderHistoryWindow op = new OrderHistoryWindow(this.orderServise, this.userContext, this.userservice);
            op.Show();
        }
    }
}
