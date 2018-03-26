using DTO;
using Services.Contacts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Client.WPF
{
    public partial class ShoppingCartWindow : Window
    {
        private IShoppingCart shoppingCart;
        private IUserContext loggedUser;
        private IProductService productService;
        private TextBlock total;
        private IOrderService orederServise;
        private IUserService user;
        private IList<TextBox> cardDetails;

        public ShoppingCartWindow(IShoppingCart shoppingCart, IUserContext loggedUser, IUserService user, IProductService productService, TextBlock total, IOrderService orederServise)
        {
            InitializeComponent();

            this.shoppingCart = shoppingCart;
            this.loggedUser = loggedUser;
            this.user = user;
            this.productService = productService;
            this.total = total;
            this.orederServise = orederServise;
            this.cardDetails = new List<TextBox>();
            FillInfo();
        }

        private void FillInfo()
        {
            this.ProductsContent.ItemsSource = this.shoppingCart.Products;
        }

        private void FinishBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DeliveryDetails.Visibility = Visibility.Visible;
            this.cardDetails.Add(this.NumberForm);
            this.cardDetails.Add(this.ExpDateForm);
            this.cardDetails.Add(this.HolderForm);
        }

        private void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DiscardBtn_Click(object sender, RoutedEventArgs e)
        {
            this.shoppingCart.Clear();
            this.Close();
            this.total.Text = $"{shoppingCart.Total:F2} $";
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            int userId = this.loggedUser.LoggedUserId.Value;
            decimal total = this.shoppingCart.Total;
            DateTime date = DateTime.Now;
            var products = this.shoppingCart.Products;
            string status = "Approved";

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var productId = int.Parse(((Button)sender).Tag.ToString());
            var product = this.productService.SearchById(productId).FirstOrDefault();

            shoppingCart.RemoveProduct(product);

            FillInfo();
        }

        private void FromProfileBtnReceiver_Click(object sender, RoutedEventArgs e)
        {
            var userNameToDisplay = this.user.GetSpecificUser(this.loggedUser.LoggedUserId.Value).FirstName + " " + this.user.GetSpecificUser(this.loggedUser.LoggedUserId.Value).LastName;
            this.RecieverName.Text = userNameToDisplay;
        }

        private void FromProfileBtnAddress_Click(object sender, RoutedEventArgs e)
        {
            TextBox addressForm = this.AddressForm;
            UserAddressesWindow op = new UserAddressesWindow(this.user, this.loggedUser, addressForm);
            op.Show();
        }

        private void FromProfileBtnBankCard_Click(object sender, RoutedEventArgs e)
        {
            BankCardSelectionWindow op = new BankCardSelectionWindow(this.loggedUser, this.user, this.cardDetails);
            op.Show();
        }
    }
}
