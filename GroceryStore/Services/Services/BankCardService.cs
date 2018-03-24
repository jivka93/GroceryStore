using AutoMapper;
using DAL.Contracts;
using Models;
using Services.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BankCardService: IBankCardService
    {
        public BankCardService(IEfGenericRepository<BankCard> bankCardRepo, IMapper mapper)
        {

        }
    }
}
