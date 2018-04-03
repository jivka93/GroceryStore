using Services.Contacts;
using System.Windows;

namespace Client.WPF
{
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
            this.OrdersContent.ItemsSource = orderServise.GetAllById(this.userContext.LoggedUserId.Value);
        }
    }
}
