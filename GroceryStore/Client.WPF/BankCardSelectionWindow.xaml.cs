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
    /// <summary>
    /// Interaction logic for BankCardSelectionWindow.xaml
    /// </summary>
    public partial class BankCardSelectionWindow : Window
    {
        private IUserContext loggedUser;
        private IUserService user;
        private IList<TextBox> cardDetails;
        public BankCardSelectionWindow(IUserContext loggedUser, IUserService user, IList<TextBox> cardDetails)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.user = user;
            this.cardDetails = cardDetails;
            Fillinfo();
        }

        private void Fillinfo()
        {
            var user = this.user.GetSpecificUser(this.loggedUser.LoggedUserId.Value);
            var Cards = user.BankCards.ToList();
            this.FirstNumber.Text = Cards[0].Number;
            this.FirstExpDate.Text = Cards[0].ExpDateAsString;
            this.FirstName.Text = Cards[0].Name;
            this.SecondNumber.Text = Cards[1].Number;
            this.SecondExpDate.Text = Cards[1].ExpDateAsString;
            this.SecondName.Text = Cards[1].Name;
            this.ThirdNumber.Text = Cards[2].Number;
            this.ThirdExpDate.Text = Cards[2].ExpDateAsString;
            this.ThirdName.Text = Cards[2].Name;
        }

        private void FirstBtn_Click(object sender, RoutedEventArgs e)
        {
            this.cardDetails[0].Text = this.FirstNumber.Text;
            this.cardDetails[1].Text = this.FirstExpDate.Text;
            this.cardDetails[2].Text = this.FirstName.Text;
            this.Close();
        }

        private void SecondBtn_Click(object sender, RoutedEventArgs e)
        {
            this.cardDetails[0].Text = this.SecondNumber.Text;
            this.cardDetails[1].Text = this.SecondExpDate.Text;
            this.cardDetails[2].Text = this.SecondName.Text;
            this.Close();
        }

        private void ThirdBtn_Click(object sender, RoutedEventArgs e)
        {
            this.cardDetails[0].Text = this.ThirdNumber.Text;
            this.cardDetails[1].Text = this.ThirdExpDate.Text;
            this.cardDetails[2].Text = this.ThirdName.Text;
            this.Close();
        }
    }
}
