using DTO;
using System.Collections.Generic;

namespace Services.Contacts
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAll();

        IEnumerable<ProductModel> SearchByName(string productName);

        IEnumerable<ProductModel> SearchById(int productId);

        IEnumerable<ProductModel> SearchByCategory(string categoryName);
    }
}
