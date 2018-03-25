using Services.Contacts;
using System.Windows;

namespace Client.WPF
{
    public partial class BankCardsWindow : Window
    {
        private readonly IUserContext userContext;
        private readonly IUserService userservice;

        public BankCardsWindow(IUserContext userContext, IUserService userservice)
        {
            InitializeComponent();

            this.userContext = userContext;
            this.userservice = userservice;

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

                // Filling:
                this.BankCardsContent.ItemsSource = userModel.BankCards;
                this.BankCardsContent.DataContext = userModel.BankCards;
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
