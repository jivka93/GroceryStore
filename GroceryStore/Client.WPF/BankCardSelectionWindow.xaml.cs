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
        private List<TextBox> cardInfo;

        public BankCardSelectionWindow(IUserContext loggedUser, IUserService user, List<TextBox> cardInfo)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.user = user;
            this.cardInfo = cardInfo;
            Fillinfo();
        }

        private void Fillinfo()
        {
            var user = this.user.GetSpecificUser(loggedUser.LoggedUserId.Value);
            var card = user.BankCards.ToList();
            this.FirstNumber.Text = card[0].Number;
            this.FirstExpDate.Text = card[0].ExpDateAsString;
            this.FirstName.Text = card[0].Name;
            this.SecondNumber.Text = card[1].Number;
            this.SecondExpDate.Text = card[1].ExpDateAsString;
            this.SecondName.Text = card[1].Name;
            this.ThirdNumber.Text = card[2].Number;
            this.ThirdExpDate.Text = card[2].ExpDateAsString;
            this.ThirdName.Text = card[2].Name;
        }

        private void FirstBtn_Click(object sender, RoutedEventArgs e)
        {
            this.cardInfo[0].Text = this.FirstNumber.Text;
            this.cardInfo[1].Text = this.FirstExpDate.Text;
            this.cardInfo[2].Text = this.FirstName.Text;
        }

        private void SecondBtn_Click(object sender, RoutedEventArgs e)
        {
            this.cardInfo[0].Text = this.SecondNumber.Text;
            this.cardInfo[1].Text = this.SecondExpDate.Text;
            this.cardInfo[2].Text = this.SecondName.Text;
        }

        private void ThirdBtn_Click(object sender, RoutedEventArgs e)
        {
            this.cardInfo[0].Text = this.ThirdNumber.Text;
            this.cardInfo[1].Text = this.SecondExpDate.Text;
            this.cardInfo[2].Text = this.SecondName.Text;
        }
    }
}
