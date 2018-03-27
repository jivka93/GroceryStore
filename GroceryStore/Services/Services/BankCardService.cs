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
        private readonly IEfGenericRepository<BankCard> bankCardRepo;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public BankCardService(IEfGenericRepository<BankCard> bankCardRepo, IMapper mapper, IUserService userService)
        {
            this.bankCardRepo = bankCardRepo;
            this.mapper = mapper;
            this.userService = userService;
        }

        public void AddNewBankCard(string number, DateTime expDate, string holderName, int userId)
        {
            var user = this.userService.GetSpecificUser(userId);

            BankCardModel bankCardDTO = new BankCardModel()
            {
                Number = number,
                ExpirationDate = expDate,
                Name = holderName,
                UserId = userId
            };

            this.bankCardRepo.Add(this.mapper.Map<BankCard>(bankCardDTO));
        }

        public bool DeleteCardById(int cardId)
        {
            try
            {
                var card = this.bankCardRepo.GetById(cardId);
                this.bankCardRepo.Delete(card);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public void GetUserBankCards(UserModel user)
        {

        }
    }
}
