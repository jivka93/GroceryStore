using Bytes2you.Validation;
using Common;
using DAL.Contracts;
using DTO;
using DTO.Contracts;
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
        private readonly IMappingProvider mapper;
        private readonly IEfGenericRepository<User> users;

        public UserService( IMappingProvider mapper, IHashingPassword hashing, IEfUnitOfWork unitOfWork, IEfGenericRepository<User> users)
        {
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();
            Guard.WhenArgument(hashing, "hashing").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();
            Guard.WhenArgument(users, "userRepo").IsNull().Throw();
            this.hashing = hashing;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.users = users;
        }

        public IEnumerable<IUserModel> GetAllUsers()
        {
            return mapper.ProjectTo<User, UserModel>(this.users.All);
        }

        public IUserModel GetSpecificUser(string userName)
        {
            Guard.WhenArgument(userName, "userName").IsNullOrEmpty().Throw();
            return mapper.ProjectTo<User, UserModel>(this.users.All).Where(x => x.Username == userName).FirstOrDefault();
        }

        public IUserModel GetSpecificUser(int userId)
        {           
            return mapper.ProjectTo<User, UserModel>(this.users.All).Where(x => x.Id == userId).FirstOrDefault();
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
            Guard.WhenArgument(phoneNumber, "phoneNumber").IsNullOrEmpty().Throw();
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

                var userToAdd = this.mapper.Map<UserModel,User>(userModel);
                var user = this.GetSpecificUser(userModel.Username);

                if (address != string.Empty && address != string.Empty)
                {
                    var a = new AddressModel() { AddressText = address };
                    var addressToAdd = this.mapper.Map<AddressModel, Address>(a);
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

                    var cardToAdd = this.mapper.Map<BankCardModel,BankCard>(c);
                    userToAdd.BankCards.Add(cardToAdd);
                }

                this.users.Add(userToAdd);
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

            var user = this.users.All.Where(x => x.Id == userId).FirstOrDefault();
            var newPassword = hashing.GetSHA1HashData(password);
            user.Password = newPassword;

            this.users.Update(user);
            this.unitOfWork.SaveChanges();
        }

        public void UpdateProfileInfo(int id, string firstName = null, string lastName = null, string phone = null)
        {
            var user = this.users.All.Where(x => x.Id == id).FirstOrDefault();

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

            this.users.Update(user);
            unitOfWork.SaveChanges();
        }

    }
}
