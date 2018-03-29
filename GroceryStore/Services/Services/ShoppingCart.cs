using Bytes2you.Validation;
using DTO;
using DTO.Contracts;
using Services.Contacts;
using System.Collections.Generic;

namespace Services.Services
{
    public class ShoppingCart : IShoppingCart
    {
        private IList<IProductModel> products;

        public ShoppingCart()
        {
            this.products = new List<IProductModel>();
        }

        public IList<IProductModel> Products { get => new List<IProductModel>(this.products); set => this.products = value; }

        public decimal Total
        {
            get
            {
                decimal total = 0m;
                foreach (var p in this.products)
                {
                    total += p.Price;
                }
                return total;
            }
        }

        public void AddProduct(IProductModel product)
        {
            Guard.WhenArgument(product, "product").IsNull().Throw();
            this.products.Add(product);
        }

        public void RemoveProduct(IProductModel product)
        {
            Guard.WhenArgument(product, "product").IsNull().Throw();

            IProductModel toRemove = null;
            for (int i = 0; i < this.products.Count; i++)
            {
                if (product.Id == this.products[i].Id)
                {
                    toRemove = this.products[i];
                    break;
                }
            }
            this.products.Remove(toRemove);
        }

        public void Clear()
        {
            this.products.Clear();
        }

    }
}
