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

        public ICollection<OrderModel> getAllById(int id)
        {

            return this.orderRepo.All.ProjectTo<OrderModel>().ToList<OrderModel>();
        }

        public void AddOrder(OrderModel order)
        {
            this.orderRepo.Add(mapper.Map<Order>(order));
        }

    }
}
