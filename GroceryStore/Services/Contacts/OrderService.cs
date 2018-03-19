using AutoMapper;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contacts
{
    public class OrderService: BaseService, IOrderService
    {
        public OrderService(IGroceryStoreContext dbContext, IMapper mapper):
            base(dbContext, mapper)
        {

        }
    }
}
