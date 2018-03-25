using Services.Contacts;
using System.Windows;

namespace Client.WPF
{
    public partial class ShoppingCartWindow : Window
    {
        private IShoppingCart shoppingCart;
        private IUserContext loggedUser;

        public ShoppingCartWindow(IShoppingCart shoppingCart, IUserContext loggedUser)
        {
            InitializeComponent();

            this.shoppingCart = shoppingCart;
            this.loggedUser = loggedUser;

            FillInfo();
        }

        private void FillInfo()
        {
            this.ProductsContent.ItemsSource = this.shoppingCart.Products;
        }

        //private void ContinueButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        //private void DiscardButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        //private void FinishOrderbutton_Click(object sender, RoutedEventArgs e)
        //{
        //    BankCardDetailsWindow op = new BankCardDetailsWindow();
        //    op.Show();
        //}

        private void FinishBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DeliveryDetails.Visibility = Visibility.Visible;
        }

        private void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DiscardBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
