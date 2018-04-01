using Models;

namespace DTO.Contracts
{
    public interface IInventoryModel
    {
        int ProductId { get; set; }

        int QuantityInStock { get; set; }

        Product Product { get; set; }
    }
}
