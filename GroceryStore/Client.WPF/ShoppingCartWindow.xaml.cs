using Services.Contacts;
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

        public ShoppingCartWindow(IShoppingCart shoppingCart, IUserContext loggedUser, IProductService productService, TextBlock total)
        {
            InitializeComponent();

            this.shoppingCart = shoppingCart;
            this.loggedUser = loggedUser;
            this.productService = productService;
            this.total = total;

            FillInfo();
        }

        private void FillInfo()
        {
            this.ProductsContent.ItemsSource = this.shoppingCart.Products;
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

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var productId = int.Parse(((Button)sender).Tag.ToString());
            var product = this.productService.SearchById(productId).FirstOrDefault();

            shoppingCart.RemoveProduct(product);

            FillInfo();
        }
    }
}
