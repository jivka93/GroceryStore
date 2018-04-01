using Bytes2you.Validation;
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
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();
            Guard.WhenArgument(orders, "orders").IsNull().Throw();

            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.orders = orders;
        }

        public void Add(OrderModel order)
        {
            Guard.WhenArgument(order, "order").IsNull().Throw();

            var mapped = mapper.Map<OrderModel, Order>(order);
            this.orders.Add(mapped);
            unitOfWork.SaveChanges();
        }

        public void AddWithoutMapping(Order order)
        {
            Guard.WhenArgument(order, "order").IsNull().Throw();

            this.orders.Add(order);
            unitOfWork.SaveChanges();
        }

        public ICollection<OrderModel> GetAllById(int id)
        {
            var allOrders = mapper.ProjectTo<Order, OrderModel>(this.orders.All).Where(x => x.UserId == id).ToList();
            return allOrders;
        }
    }
}
