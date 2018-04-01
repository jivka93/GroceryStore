using DTO;
using Models;
using System.Collections.Generic;

namespace Services.Contacts
{
    public interface IOrderService
    {
        ICollection<OrderModel> GetAllById(int id);

        void Add(OrderModel order);

        void AddWithoutMapping(Order order);
    }
}
