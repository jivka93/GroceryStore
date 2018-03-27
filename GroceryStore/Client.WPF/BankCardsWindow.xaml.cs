using Services.Contacts;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Client.WPF
{
    public partial class BankCardsWindow : Window
    {
        private readonly IUserContext userContext;
        private readonly IUserService userservice;
        private readonly IBankCardService bankCardService;

        public BankCardsWindow(IUserContext userContext, IUserService userservice, IBankCardService bankCardService)
        {
            InitializeComponent();

            this.userContext = userContext;
            this.userservice = userservice;
            this.bankCardService = bankCardService;

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

                if (userModel.BankCards.Count > 2)
                {
                    this.AddNew.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.AddNew.Visibility = Visibility.Visible;
                }

                // Filling:
                this.BankCardsContent.ItemsSource = userModel.BankCards;
                this.BankCardsContent.DataContext = userModel.BankCards;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string number = this.NewCardNumber.Text.Trim();
            string holderName = this.NewCardName.Text.Trim();

            try
            {
                DateTime expDate = DateTime.ParseExact(this.NewCardExpDate.Text.Trim(), "MM-yyyy", CultureInfo.InvariantCulture);
                if (number == null ||
                    number == string.Empty ||
                    number.Length != 16 ||
                    number.All(x => !char.IsDigit(x)) ||
                    holderName == null ||
                    holderName == string.Empty ||
                    holderName.Length < 3)
                {
                    MessageBoxResult message = MessageBox
                        .Show("Invalid number or name!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    this.bankCardService.AddNewBankCard(number, expDate, holderName, (int)this.userContext.LoggedUserId);

                    MessageBoxResult message = MessageBox
                        .Show("Address is saved successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.FillInfo();
                }
            }
            catch (Exception)
            {
                MessageBoxResult message = MessageBox
                    .Show("Invalid expiry date!", "", MessageBoxButton.OK, MessageBoxImage.Information);               
            }

        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var tag = button.Tag;

            var bankCardId = int.Parse(((Button)sender).Tag.ToString());
            var result = this.bankCardService.DeleteCardById(bankCardId);

            if (result)
            {
                MessageBoxResult message = MessageBox
                    .Show("Bank card deleted successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);

                FillInfo();
            }
            else
            {
                MessageBoxResult message = MessageBox
                    .Show("Deleting failed!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
