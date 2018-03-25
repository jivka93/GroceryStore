using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Contracts;
using DTO;
using Models;
using Services.Contacts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Services
{
    public class UserService : IUserService
    {

        private readonly IEfGenericRepository<User> usersRepo;
        private readonly IHashingPassword hashing;
        private readonly IMapper mapper;

        public UserService(IEfGenericRepository<User> usersRepo, IMapper mapper, IHashingPassword hashing)
        {
            this.usersRepo = usersRepo;
            this.hashing = hashing;
            this.mapper = mapper;
        }

        public IEnumerable<UserModel> GetAllUsers()  // We will use this one to check if the inputed username and password match.
        {
            return this.usersRepo.All.ProjectTo<UserModel>();
        }

        public UserModel GetSpecificUser(string userName) //This one will be used to visualize when the user select "MyProfile"
        {
            return this.usersRepo.All.ProjectTo<UserModel>().Where(x => x.Username == userName).FirstOrDefault();
        }

        public UserModel GetSpecificUser(int userId) //This one will be used when the user select update in "MyProfile"
        {
            return this.usersRepo.All.ProjectTo<UserModel>().Where(x => x.Id == userId).FirstOrDefault();
        }


        public bool RegisterUser
            (string userName, string password,string phoneNumber, 
            string firstName = null, 
            string lastName = null, 
            string address = null, 
            string bankCardNumber = null, 
            DateTime? expDate = null, 
            string cardName = null)
        {
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

                usersRepo.Add(userToAdd);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public void UpdatePassword(int id, string password)
        {
            var user = this.usersRepo.All.Where(x => x.Id == id).FirstOrDefault();
            var newPassword = hashing.GetSHA1HashData(password);
            user.Password = newPassword;

            this.usersRepo.Update(user);
        }

        public void UpdateProfileInfo(int id, string firstName = null, string lastName = null, string phone = null)
        {
            var user = this.usersRepo.All.Where(x => x.Id == id).FirstOrDefault();

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

            this.usersRepo.Update(user);
        }

    }
}
