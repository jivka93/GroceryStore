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
using Models;

namespace Services
{
    public class AddressService: IAddressService
    {
        public AddressService(IEfGenericRepository<Address> addressRepo, IMapper mapper)
        {

        }

    }
}
