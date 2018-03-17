using Common.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductModel : IMapFrom<Product>
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public virtual Inventory Inventory { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
