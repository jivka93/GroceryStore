using Common.Mapping;
using DTO.Contracts;
using Models;

namespace DTO
{
    public class InventoryModel: IMapFrom<Inventory>, IInventoryModel
    {
        public int ProductId { get; set; }

        public int QuantityInStock { get; set; }

        public virtual Product Product { get; set; }
    }
}
