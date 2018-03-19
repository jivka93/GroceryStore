using Models;
using Services.Contacts;
using System.Windows;

namespace Client.WPF
{
    public partial class LoginWindow : Window
    {
        private readonly IUserContext userContext;

        public LoginWindow(IUserContext userContext)
        {
            InitializeComponent();
            this.userContext = userContext;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            //todo validation
            var userName = this.UsernameTextBox.Text;
            var password = this.PasswordTextBox.Text;

            User user = this.userContext.CheckLogin(userName, password);

            if (user != null)
            {
                this.userContext.Login(user.Id);
            }
            else
            {
                ErrorTEST op = new ErrorTEST();
                op.Show();
            }
        }
    }
}
