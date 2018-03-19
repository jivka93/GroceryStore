using Common.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderModel: IMapFrom<Order>
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
