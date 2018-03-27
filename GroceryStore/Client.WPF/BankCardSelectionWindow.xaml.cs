using Services.Contacts;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Client.WPF
{
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
            var cards = user.BankCards.ToList();

            if (cards.Count > 0)
            {
                this.Card1.Visibility = Visibility.Visible;
                this.FirstNumber.Text = cards[0].Number;
                this.FirstExpDate.Text = cards[0].ExpDateAsString;
                this.FirstName.Text = cards[0].Name;
            }
            if (cards.Count > 1)
            {
                this.Card2.Visibility = Visibility.Visible;
                this.SecondNumber.Text = cards[1].Number;
                this.SecondExpDate.Text = cards[1].ExpDateAsString;
                this.SecondName.Text = cards[1].Name;
            }
            if (cards.Count > 2)
            {
                this.Card3.Visibility = Visibility.Visible;
                this.ThirdNumber.Text = cards[2].Number;
                this.ThirdExpDate.Text = cards[2].ExpDateAsString;
                this.ThirdName.Text = cards[2].Name;
            }

        }

        private void FirstBtn_Click(object sender, RoutedEventArgs e)
        {
            this.cardInfo[0].Text = this.FirstNumber.Text;
            this.cardInfo[1].Text = this.FirstExpDate.Text;
            this.cardInfo[2].Text = this.FirstName.Text;
            this.Close();
        }

        private void SecondBtn_Click(object sender, RoutedEventArgs e)
        {
            this.cardInfo[0].Text = this.SecondNumber.Text;
            this.cardInfo[1].Text = this.SecondExpDate.Text;
            this.cardInfo[2].Text = this.SecondName.Text;
            this.Close();
        }

        private void ThirdBtn_Click(object sender, RoutedEventArgs e)
        {
            this.cardInfo[0].Text = this.ThirdNumber.Text;
            this.cardInfo[1].Text = this.ThirdExpDate.Text;
            this.cardInfo[2].Text = this.ThirdName.Text;
            this.Close();
        }
    }
}
