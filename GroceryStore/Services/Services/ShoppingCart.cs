﻿using Bytes2you.Validation;
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
            this.products.Remove(product);
        }

        public void Clear()
        {
            this.Products = new List<ProductModel>();
        }

    }
}
