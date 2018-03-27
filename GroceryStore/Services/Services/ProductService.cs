using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
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

        public ProductService(IEfUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return this.unitOfWork.Products.All.ProjectTo<ProductModel>();
        }

        public Product GetProductDirectlyFromDB(int productId)
        {
            return this.unitOfWork.Products.GetById(productId);         
        }

        public IEnumerable<ProductModel> SearchByName(string productName)
        {
            Guard.WhenArgument(productName, "productName").IsNullOrEmpty().Throw();
            return this.unitOfWork.Products.All.ProjectTo<ProductModel>().Where(x => x.Name.ToUpper().Contains(productName.ToUpper()));
        }

        public IEnumerable<ProductModel> SearchById(int productId)
        {
            return this.unitOfWork.Products.All.ProjectTo<ProductModel>().Where(x => x.Id == productId);
        }

        public IEnumerable<ProductModel> SearchByCategory(string categoryName)
        {
            Guard.WhenArgument(categoryName, "categoryName").IsNullOrEmpty().Throw();
            return this.unitOfWork.Products.All.ProjectTo<ProductModel>().Where(x => x.Category == categoryName);
        }

        public void AddProducts(ICollection<Product> products) // productsDTO
        {
            // TODO use DTO objects
            //var p = IQueryable<ProductModel>((x) => Mapper.Map<ProductModel>(x));
            //var products = (IQueryable<ProductModel>(productsDTO)).ProjectTo<Product>();

            this.unitOfWork.Products.Add(products);
            unitOfWork.SaveChanges();
        }
    }
}
