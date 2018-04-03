using Models;
using Services.Contacts;
using System.Windows;

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

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            var userName = this.UsernameTextBox.Text;
            var password = this.PasswordTextBox.Password;

            if (userName == null || userName == string.Empty || password == null || password == string.Empty)
            {
                MessageBoxResult result = MessageBox.Show("Invalid username or password! Please try again!", "", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (result == MessageBoxResult.Cancel)
                {
                    this.Close();
                }
                this.UsernameTextBox.Text = "";
                this.PasswordTextBox.Password = "";
            }
            else
            {
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
}
