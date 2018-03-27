using Bytes2you.Validation;
using DTO;
using Services.Contacts;
using System.Collections.Generic;

namespace Services.Services
{
    public class ShoppingCart : IShoppingCart
    {
        private IList<ProductModel> products;

        public ShoppingCart()
        {
            this.products = new List<ProductModel>();
        }

        public IList<ProductModel> Products { get => new List<ProductModel>(this.products); set => this.products = value; }

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

        public void AddProduct(ProductModel product)
        {
            Guard.WhenArgument(product, "product").IsNull().Throw();
            this.products.Add(product);
        }

        public void RemoveProduct(ProductModel product)
        {
            Guard.WhenArgument(product, "product").IsNull().Throw();

            ProductModel toRemove = null;
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
