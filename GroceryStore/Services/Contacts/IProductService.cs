using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contacts
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAllAvailableProducts();

        IEnumerable<ProductModel> GetAllAvailableProductByCategory(string category);
    }
}
