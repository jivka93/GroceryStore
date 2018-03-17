using AutoMapper;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService
    {        

        protected BaseService(IGroceryStoreContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public IGroceryStoreContext DbContext { get; }
        public IMapper Mapper { get; }
    }
}
