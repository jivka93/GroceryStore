using AutoMapper.QueryableExtensions;
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
            Guard.WhenArgument(unitOfWork, "unitofwork").IsNull().Throw();
            Guard.WhenArgument(products, "GenRepo").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();
            this.unitOfWork = unitOfWork;
            this.products = products;
            this.mapper = mapper;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            //return this.products.All.ProjectTo<ProductModel>();
            return mapper.ProjectTo<Product, ProductModel>(this.products.All);
        }

        public Product GetProductDirectlyFromDB(int productId)
        {
            return this.products.GetById(productId);         
        }

        public IEnumerable<ProductModel> SearchByName(string productName)
        {
            Guard.WhenArgument(productName, "productName").IsNullOrEmpty().Throw();
            //return this.products.All.ProjectTo<ProductModel>().Where(x => x.Name.ToUpper().Contains(productName.ToUpper()));
            return mapper.ProjectTo<Product, ProductModel>(this.products.All).Where(x => x.Name.ToUpper().Contains(productName.ToUpper()));
        }

        public IEnumerable<ProductModel> SearchById(int productId)
        {
            //return this.products.All.ProjectTo<ProductModel>().Where(x => x.Id == productId);
            return mapper.ProjectTo<Product, ProductModel>(this.products.All).Where(x => x.Id == productId);
        }

        public IEnumerable<ProductModel> SearchByCategory(string categoryName)
        {
            Guard.WhenArgument(categoryName, "categoryName").IsNullOrEmpty().Throw();
            //return this.products.All.ProjectTo<ProductModel>().Where(x => x.Category == categoryName);
            return mapper.ProjectTo<Product, ProductModel>(this.products.All).Where(x => x.Category == categoryName);
        }

        public void AddProducts(ICollection<Product> products)
        {
            this.products.Add(products);
            unitOfWork.SaveChanges();
        }
    }   
}
