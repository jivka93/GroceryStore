using AutoMapper;
using DAL.Contracts;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Services.Contacts;

namespace Services
{
    public class AddressService: BaseService, IAddressService
    {
        public AddressService(IGroceryStoreContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public void UpdateAddress(AddressModel address)
        {
            //base.DbContext.Addresses.FirstOrDefault(x => x.Id == address.Id).
        }
    }
}
