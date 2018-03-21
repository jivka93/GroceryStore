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
        private readonly IEfGenericRepository<Product> usersRepo;

        public ProductService(IEfGenericRepository<Product> usersRepo, IMapper mapper)
        {
            this.usersRepo = usersRepo;
        }

        public IEnumerable<ProductModel> SearchByName(string productName)
        {
            return this.usersRepo.All.ProjectTo<ProductModel>().Where(x => x.Name.Contains(productName));
        }

        public IEnumerable<ProductModel> SearchByCategory(string categoryName)
        {
            return this.usersRepo.All.ProjectTo<ProductModel>().Where(x => x.Category ==categoryName);
        }
    }
}
