using Bytes2you.Validation;
using Common;
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
        private readonly IEfUnitOfWork unitOfWork;
        private readonly IEfGenericRepository<Product> products;
        private readonly IMappingProvider mapper;

        public ProductService(IEfUnitOfWork unitOfWork, IEfGenericRepository<Product> products, IMappingProvider mapper)
        {
            this.unitOfWork = unitOfWork;
            this.products = products;
            this.mapper = mapper;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return mapper.ProjectTo<Product, ProductModel>(this.products.All);
        }

        public Product GetProductDirectlyFromDB(int productId)
        {
            return this.products.GetById(productId);         
        }

        public IEnumerable<ProductModel> SearchByName(string productName)
        {
            Guard.WhenArgument(productName, "productName").IsNullOrEmpty().Throw();
            return mapper.ProjectTo<Product, ProductModel>(this.products.All).Where(x => x.Name.ToUpper().Contains(productName.ToUpper()));
        }

        public IEnumerable<ProductModel> SearchById(int productId)
        {
            return mapper.ProjectTo<Product, ProductModel>(this.products.All).Where(x => x.Id == productId);
        }

        public IEnumerable<ProductModel> SearchByCategory(string categoryName)
        {
            Guard.WhenArgument(categoryName, "categoryName").IsNullOrEmpty().Throw();
            return mapper.ProjectTo<Product, ProductModel>(this.products.All).Where(x => x.Category == categoryName);
        }

        public void AddProducts(ICollection<Product> products)
        {
            Guard.WhenArgument(products, "products").IsNull().Throw();
            this.products.Add(products);
            unitOfWork.SaveChanges();
        }
    }   
}
