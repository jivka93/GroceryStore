using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client.WPF
{
    /// <summary>
    /// Interaction logic for RegisterUserWindow.xaml
    /// </summary>
    public partial class RegisterUserWindow : Window
    {
        public RegisterUserWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            //todo validation
            var userName = this.UsernameTextBox.Text;
            var password = this.PasswordTextBox.Text;
            var phoneNumber = this.PhoneTextBox.Text;
            var firstName = this.FirstnameTextBox.Text;
            var lastName = this.LastnameTextBox.Text;
            

        }
    }
}
