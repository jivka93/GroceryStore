using DTO;
using Services.Contacts;
using System.Collections.Generic;

namespace Services.Services
{
    public class ShoppingCart : IShoppingCart
    {
        private ICollection<ProductModel> products;

        public ShoppingCart()
        {
            this.products = new List<ProductModel>();
        }

        public ICollection<ProductModel> Products { get => new List<ProductModel>(this.products); set => this.products = value; }

        public decimal Total
        {
            get
            {
                decimal total = 0m;
                foreach (var p in this.Products)
                {
                    total += p.Price;
                }
                return total;
            }
        }

        public void AddProduct(ProductModel product)
        {
            this.Products.Add(product);
        }

    }
}
