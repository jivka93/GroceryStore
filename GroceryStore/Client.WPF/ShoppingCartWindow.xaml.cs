using System.Windows;

namespace Client.WPF
{
    public partial class ShoppingCartWindow : Window
    {
        public ShoppingCartWindow()
        {
            InitializeComponent();
        }

        private void Continuebutton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DiscardButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FinishOrderbutton_Click(object sender, RoutedEventArgs e)
        {
            BankCardDetailsWindow op = new BankCardDetailsWindow();
            op.Show();
        }
    }
}
