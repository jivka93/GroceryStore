using Bytes2you.Validation;
using Common;
using DAL.Contracts;
using DTO;
using Models;
using Services.Contacts;
using System;

namespace Services
{
    public class BankCardService: IBankCardService
    {
        private readonly IEfUnitOfWork unitOfWork;
        private readonly IMappingProvider mapper;
        private readonly IUserService userService;
        private readonly IEfGenericRepository<BankCard> bankCards;

        public BankCardService(IEfUnitOfWork unitOfWork, IMappingProvider mapper, IUserService userService, IEfGenericRepository<BankCard> bankCards)
        {
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(bankCards, "bankCards").IsNull().Throw();
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userService = userService;
            this.bankCards = bankCards;
        }

        public void AddNewBankCard(string number, DateTime expDate, string holderName, int userId)
        {
            Guard.WhenArgument(number, "number").IsNull().Throw();
            Guard.WhenArgument(holderName, "holderName").IsNull().Throw();

            BankCardModel bankCardDTO = new BankCardModel()
            {
                Number = number,
                ExpirationDate = expDate,
                Name = holderName,
                UserId = userId
            };

            this.bankCards.Add(this.mapper.Map<BankCardModel, BankCard>(bankCardDTO));
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
