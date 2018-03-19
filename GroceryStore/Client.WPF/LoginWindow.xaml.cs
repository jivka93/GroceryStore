using Models;
using Services.Contacts;
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
    public partial class LoginWindow : Window
    {
        private readonly IUserService userservice;
        private readonly IUserContext userContext;

        public LoginWindow(IUserService userservice, IUserContext userContext)
        {
            InitializeComponent();
            this.userservice = userservice;
            this.userContext = userContext;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            //todo validation
            var userName = this.UsernameTextBox.Text;
            var password = this.PasswordTextBox.Text;

            User user = this.userservice.CheckLogin(userName, password);

            if (user != null)
            {
                this.userContext.Login(user.Id);
            }
            else
            {

            }
        }
    }
}
