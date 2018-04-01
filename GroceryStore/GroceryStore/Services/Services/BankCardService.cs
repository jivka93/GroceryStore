using AutoMapper;
using DAL.Contracts;
using DTO;
using DTO.Contracts;
using Models;
using Services.Contacts;
using System;

namespace Services
{
    public class BankCardService: IBankCardService
    {
        private readonly IEfUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IEfGenericRepository<BankCard> bankCards;

        public BankCardService(IEfUnitOfWork unitOfWork, IMapper mapper, IUserService userService, IEfGenericRepository<BankCard> bankCards)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userService = userService;
            this.bankCards = bankCards;
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

            this.bankCards.Add(this.mapper.Map<BankCard>(bankCardDTO));
            unitOfWork.SaveChanges();
        }

        public bool DeleteCardById(int cardId)
        {
            try
            {
                var card = this.bankCards.GetById(cardId);
                this.bankCards.Delete(card);
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
