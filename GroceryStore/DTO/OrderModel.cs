using Common.Mapping;
using DTO.Contracts;
using Models;
using System;
using System.Collections.Generic;

namespace DTO
{
    public class OrderModel : IMapFrom<Order>, IOrderModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }

        public string Status { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<ProductModel> Products { get; set; }
    }
}
