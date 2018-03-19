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
    public class BankCardService: BaseService, IBankCardService
    {
        public BankCardService(IGroceryStoreContext dbContext, IMapper mapper) :
            base(dbContext, mapper)
        {

        }
    }
}
