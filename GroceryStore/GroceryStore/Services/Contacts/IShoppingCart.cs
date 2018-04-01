using DTO;
using DTO.Contracts;
using System.Collections.Generic;

namespace Services.Contacts
{
    public interface IShoppingCart
    {
        IList<IProductModel> Products { get; set; }

        decimal Total { get; }

        void AddProduct(IProductModel product);

        void RemoveProduct(IProductModel product);

        void Clear();
    }
}
