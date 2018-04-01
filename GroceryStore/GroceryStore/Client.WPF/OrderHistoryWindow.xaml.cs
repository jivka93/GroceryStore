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
    /// Interaction logic for OrderHistoryWindow.xaml
    /// </summary>
    public partial class OrderHistoryWindow : Window
    {
        private readonly IOrderService orderServise;
        private readonly IUserContext userContext;

        public OrderHistoryWindow(IOrderService orderServise, IUserContext userContext)
        {
            InitializeComponent();
            
            this.orderServise = orderServise;
            this.userContext = userContext;
            Fillinfo();
        }

        private void Fillinfo()
        {
            //var b = orderServise.GetAllById(14);
            this.OrdersContent.ItemsSource = orderServise.GetAllById(this.userContext.LoggedUserId.Value);
        }
    }
}
