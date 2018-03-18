using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Contracts;
using DTO;
using Services.Contacts;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IGroceryStoreContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public IEnumerable<ProductModel> GetAllAvailableProducts()
        {
            return base.DbContext.Products.ProjectTo<ProductModel>()
                .Where(x => x.Inventory.QuantityInStock > 0);
        }

        public IEnumerable<ProductModel> GetAllAvailableProductByCategory(string category)
        {
            return base.DbContext.Products.ProjectTo<ProductModel>()
                .Where(x => x.Inventory.QuantityInStock > 0).Where(x => x.Category == category);
        }

    }
}
