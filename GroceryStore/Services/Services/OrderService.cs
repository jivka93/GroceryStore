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
        private readonly IEfGenericRepository<Order> orderRepo;
        private readonly IMapper mapper;

        public OrderService(IEfGenericRepository<Order> orderRepo, IMapper mapper)            
        {
            this.orderRepo = orderRepo;
            this.mapper = mapper;
        }

        public void Add(OrderModel order)
        {
            var mapped = mapper.Map<Order>(order);
            this.orderRepo.Add(mapped);
        }

        public void AddWithoutMapping(Order order)
        {
            this.orderRepo.Add(order);
        }

        public ICollection<OrderModel> GetAllById(int id)
        {
            var allOrders = this.orderRepo.All.ProjectTo<OrderModel>();
            return allOrders.Where(x => x.UserId == id).ToList();
        }
    }
}
