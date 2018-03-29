using Common.Mapping;
using DTO.Contracts;
using Models;

namespace DTO
{
    public class ProductModel : IMapFrom<Product>, IProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }
    }
}
