using AutoMapper;
using DAL.Contracts;
using DTO;
using DTO.Contracts;
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
        private readonly IEfUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public BankCardService(IEfUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userService = userService;
        }

        public void AddNewBankCard(string number, DateTime expDate, string holderName, int userId)
        {
            var user = this.userService.GetSpecificUser(userId);

            IBankCardModel bankCardDTO = new BankCardModel()
            {
                Number = number,
                ExpirationDate = expDate,
                Name = holderName,
                UserId = userId
            };

            unitOfWork.BankCards.Add(this.mapper.Map<BankCard>(bankCardDTO));
            unitOfWork.SaveChanges();
        }

        public bool DeleteCardById(int cardId)
        {
            try
            {
                var card = unitOfWork.BankCards.GetById(cardId);
                unitOfWork.BankCards.Delete(card);
                unitOfWork.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
