using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contacts
{
    public interface IOrderService
    {
        ICollection<OrderModel> getAllById(int id);
        void AddOrder(OrderModel order);
    }
}
