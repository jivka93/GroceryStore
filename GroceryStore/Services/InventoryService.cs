using AutoMapper;
using DAL.Contracts;
using Services.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class InventoryService: BaseService, IInventoryService
    {
        public InventoryService(IGroceryStoreContext dbContext, IMapper mapper):
            base(dbContext, mapper)
        {

        }
    }
}
