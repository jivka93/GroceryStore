using DTO;
using Models;
using Services.Contacts;
using System;
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
        private IOrderService order;
        private TextBlock total;
        private List<TextBox> cardInfo;
        private IUserService user;

        public ShoppingCartWindow(IShoppingCart shoppingCart, IUserContext loggedUser, IUserService user, IProductService productService, IOrderService order, TextBlock total)
        {
            InitializeComponent();

            this.shoppingCart = shoppingCart;
            this.loggedUser = loggedUser;
            this.user = user;
            this.productService = productService;
            this.order = order;
            this.total = total;
            this.cardInfo = new List<TextBox>();
            FillInfo();
        }

        private void FillInfo()
        {
            this.ProductsContent.ItemsSource = this.shoppingCart.Products;
            this.Total.Text = $"{this.shoppingCart.Total:F2} $";
        }

        private void FinishBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DeliveryDetails.Visibility = Visibility.Visible;
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
            DateTime dateadded = DateTime.Now;
            decimal total = this.shoppingCart.Total;
            string status = "Approved";
            int userid = this.loggedUser.LoggedUserId.Value;

            var products = new List<Product>();

            foreach (var item in this.shoppingCart.Products)
            {
                var product = this.productService.GetProductDirectlyFromDB(item.Id);
                products.Add(product);
            }

            var orderToBeAdded = new Order
            {
                Date = dateadded,
                Total = total,
                Status = status,
                UserId = userid,
                Products = products,
            };

            order.AddWithoutMapping(orderToBeAdded);

            MessageBoxResult result = MessageBox
                .Show("Your order is approved!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
            this.shoppingCart.Clear();
            this.total.Text = $"{shoppingCart.Total:F2} $";
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var productId = int.Parse(((Button)sender).Tag.ToString());
            var product = this.productService.SearchById(productId).FirstOrDefault();

            shoppingCart.RemoveProduct(product);
            this.total.Text = $"{shoppingCart.Total:F2} $";

            FillInfo();
        }

        private void FromProfileBtnReceiver_Click(object sender, RoutedEventArgs e)
        {
            int userId = (int)this.loggedUser.LoggedUserId;
            var currentUser = this.user.GetSpecificUser(userId);

            if (currentUser.FirstName == null || currentUser.LastName == null || currentUser.FirstName == string.Empty || currentUser.LastName == string.Empty)
            {
                MessageBoxResult result = MessageBox
                    .Show("You don't have a name in your profile!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var userNameToDisplay = this.user.GetSpecificUser(this.loggedUser.LoggedUserId.Value).FirstName + " " + this.user.GetSpecificUser(this.loggedUser.LoggedUserId.Value).LastName;
                this.RecieverName.Text = userNameToDisplay;
            }
        }

        private void FromProfileBtnAddress_Click(object sender, RoutedEventArgs e)
        {
            int userId = (int)this.loggedUser.LoggedUserId;
            var currentUser = this.user.GetSpecificUser(userId);
            var addresses = currentUser.Adresses;

            if (addresses == null || addresses.Count == 0)
            {
                MessageBoxResult result = MessageBox
                    .Show("You have no addresses saved!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                TextBox addressForm = this.AddressForm;
                UserAddressesWindow op = new UserAddressesWindow(this.user, this.loggedUser, addressForm);
                op.Show();
            }

        }

        private void FromProfileCard_Click(object sender, RoutedEventArgs e)
        {
            int userId = (int)this.loggedUser.LoggedUserId;
            var currentUser = this.user.GetSpecificUser(userId);
            var bankCards = currentUser.BankCards;

            if (bankCards == null || bankCards.Count == 0)
            {
                MessageBoxResult result = MessageBox
                    .Show("You have no BankCards saved!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                cardInfo.Add(this.NumberForm);
                cardInfo.Add(this.ExpDateForm);
                cardInfo.Add(this.HolderForm);
                BankCardSelectionWindow op = new BankCardSelectionWindow(this.loggedUser, this.user, this.cardInfo);
                op.Show();
            }


        }
    }
}
