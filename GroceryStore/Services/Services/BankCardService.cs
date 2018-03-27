using AutoMapper;
using DAL.Contracts;
using DTO;
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
        public BankCardService(IEfUnitOfWork unitOfWork, IMapper mapper)
        {

        }

        public void GetUserBankCards(UserModel user)
        {

        }
    }
}
