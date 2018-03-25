using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Contracts;
using DTO;
using Models;
using Services.Contacts;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IEfGenericRepository<Product> productsRepo;

        public ProductService(IEfGenericRepository<Product> productsRepo, IMapper mapper)
        {
            this.productsRepo = productsRepo;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return this.productsRepo.All.ProjectTo<ProductModel>();
        }       

        public IEnumerable<ProductModel> SearchByName(string productName)
        {
            return this.productsRepo.All.ProjectTo<ProductModel>().Where(x => x.Name.Contains(productName));
        }

        public IEnumerable<ProductModel> SearchById(int productId)
        {
            return this.productsRepo.All.ProjectTo<ProductModel>().Where(x => x.Id == productId);
        }

        public IEnumerable<ProductModel> SearchByCategory(string categoryName)
        {
            return this.productsRepo.All.ProjectTo<ProductModel>().Where(x => x.Category == categoryName);
        }
    }
}
