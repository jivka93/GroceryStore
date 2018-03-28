using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Contracts;
using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contacts
{
    public class OrderService: IOrderService
    {
        private readonly IEfUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrderService(IEfUnitOfWork unitOfWork, IMapper mapper)            
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void Add(OrderModel order)
        {
            var mapped = mapper.Map<Order>(order);
            unitOfWork.Orders.Add(mapped);
            unitOfWork.SaveChanges();
        }

        public void AddWithoutMapping(Order order)
        {
            unitOfWork.Orders.Add(order);
            unitOfWork.SaveChanges();
        }


        public ICollection<OrderModel> GetAllById(int id)
        {
            var allOrders = this.unitOfWork.Orders.All.ProjectTo<OrderModel>();
            return allOrders.Where(x => x.UserId == id).ToList();
        }
    }
}
