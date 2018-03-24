using Common.Mapping;
using Models;
using System.Collections.Generic;

namespace DTO
{
    public class ProductModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public InventoryModel Inventory { get; set; }

        //public ICollection<OrderModel> Orders { get; set; }
    }
}
