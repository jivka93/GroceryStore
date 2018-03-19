using Common.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class InventoryModel: IMapFrom<Inventory>
    {
        public int ProductId { get; set; }

        public int QuantityInStock { get; set; }

        public virtual Product Product { get; set; }
    }
}
