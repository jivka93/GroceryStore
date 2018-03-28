using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using DAL.Contracts;
using DTO;
using Models;
using Services.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IHashingPassword hashing;
        private readonly IEfUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService( IMapper mapper, IHashingPassword hashing, IEfUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(hashing, "hashing").IsNull().Throw();
            this.hashing = hashing;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return this.unitOfWork.Users.All.ProjectTo<UserModel>();
        }

        public UserModel GetSpecificUser(string userName)
        {
            Guard.WhenArgument(userName, "userName").IsNullOrEmpty().Throw();
            return this.unitOfWork.Users.All.ProjectTo<UserModel>().Where(x => x.Username == userName).FirstOrDefault();
        }

        public UserModel GetSpecificUser(int userId)
        {           
            return this.unitOfWork.Users.All.ProjectTo<UserModel>().Where(x => x.Id == userId).FirstOrDefault();
        }

        public bool RegisterUser
            (string userName, string password, string phoneNumber, 
            string firstName = null, 
            string lastName = null, 
            string address = null, 
            string bankCardNumber = null, 
            DateTime? expDate = null, 
            string cardName = null)
        {
            Guard.WhenArgument(userName, "userName").IsNullOrEmpty().Throw();
            Guard.WhenArgument(password, "password").IsNullOrEmpty().Throw();
            try
            {
                var hashedPassword = hashing.GetSHA1HashData(password);

                var userModel = new UserModel()
                {
                    Username = userName,
                    Password = hashedPassword,
                    PhoneNumber = phoneNumber,
                    FirstName = firstName,
                    LastName = lastName,
                };

                var userToAdd = Mapper.Map<User>(userModel);
                var user = this.GetSpecificUser(userModel.Username);

                if (address != string.Empty && address != string.Empty)
                {
                    var a = new AddressModel() { AddressText = address };
                    var addressToAdd = this.mapper.Map<Address>(a);
                    userToAdd.Adresses.Add(addressToAdd);
                }

                if (bankCardNumber != string.Empty && expDate != null && cardName != string.Empty && bankCardNumber != null && expDate != null && cardName != null)
                {
                    var c = new BankCardModel()
                    {
                        Number = bankCardNumber,
                        ExpirationDate = expDate,
                        Name = cardName,
                        User = userToAdd
                    };

                    var cardToAdd = this.mapper.Map<BankCard>(c);
                    userToAdd.BankCards.Add(cardToAdd);
                }

                unitOfWork.Users.Add(userToAdd);
                unitOfWork.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public void UpdatePassword(int userId, string password)
        {
            Guard.WhenArgument(password, "password").IsNullOrEmpty().Throw();

            var user = this.unitOfWork.Users.All.Where(x => x.Id == userId).FirstOrDefault();
            var newPassword = hashing.GetSHA1HashData(password);
            user.Password = newPassword;

            unitOfWork.Users.Update(user);
            unitOfWork.SaveChanges();
        }

        public void UpdateProfileInfo(int id, string firstName = null, string lastName = null, string phone = null)
        {
            var user = this.unitOfWork.Users.All.Where(x => x.Id == id).FirstOrDefault();

            if (firstName != null && firstName != string.Empty)
            {
                user.FirstName = firstName;
            }

            if (lastName != null && lastName != string.Empty)
            {
                user.LastName = lastName;
            }

            if (phone != null && phone != string.Empty)
            {
                user.PhoneNumber = phone;
            }

            unitOfWork.Users.Update(user);
            unitOfWork.SaveChanges();
        }

    }
}
