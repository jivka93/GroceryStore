using Models;
using Services.Contacts;
using System.Windows;
using System.Windows.Input;

namespace Client.WPF
{
    public partial class LoginWindow : Window
    {
        private readonly IUserContext userContext;
        private readonly MainWindow mainWindow;

        public LoginWindow(IUserContext userContext, MainWindow mainWindow)
        {
            InitializeComponent();
            this.userContext = userContext;
            this.mainWindow = mainWindow;
        }


        //private void SignIn_Enter(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        SignInButton_Click()
        //    }
        //}

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {

            //todo validation

            var userName = this.UsernameTextBox.Text;
            var password = this.PasswordTextBox.Password;

            User user = this.userContext.CheckLogin(userName, password);

            if (user != null)
            {
                this.userContext.Login(user.Id);
                this.mainWindow.DisplayLoggedUserView();
                this.Close();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Invalid username or password! Please try again!", "", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (result == MessageBoxResult.Cancel)
                {
                   this.Close();
                }
                this.UsernameTextBox.Text = "";
                this.PasswordTextBox.Password = "";

            }
        }
    }
}
