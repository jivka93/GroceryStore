using DTO;
using System.Collections.Generic;

namespace Services.Contacts
{
    public interface IShoppingCart
    {
        ICollection<ProductModel> Products { get; set; }

        decimal Total { get; }

        void AddProduct(ProductModel product);

        void RemoveProduct(ProductModel product);

        void Clear();
    }
}
