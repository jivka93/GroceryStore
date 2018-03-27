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
        ICollection<OrderModel> GetAllById(int id);

        void Add(OrderModel order);
    }
}
