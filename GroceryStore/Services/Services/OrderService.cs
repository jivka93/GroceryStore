using Common;
using DAL.Contracts;
using DTO;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Services.Contacts
{
    public class OrderService: IOrderService
    {
        private readonly IEfUnitOfWork unitOfWork;
        private readonly IMappingProvider mapper;
        private readonly IEfGenericRepository<Order> orders;

        public OrderService(IEfUnitOfWork unitOfWork, IMappingProvider mapper, IEfGenericRepository<Order> orders)            
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.orders = orders;
        }

        public void Add(OrderModel order)
        {
            var mapped = mapper.Map<OrderModel, Order>(order);
            this.orders.Add(mapped);
            unitOfWork.SaveChanges();
        }

        public void AddWithoutMapping(Order order)
        {
            this.orders.Add(order);
            unitOfWork.SaveChanges();
        }

        public ICollection<OrderModel> GetAllById(int id)
        {
            //var allOrders = this.orders.All.ProjectTo<OrderModel>().Where(x => x.UserId == id).ToList();
            var allOrders = mapper.ProjectTo<Order, OrderModel>(this.orders.All).Where(x => x.UserId == id).ToList();
            return allOrders;
        }
    }
}
