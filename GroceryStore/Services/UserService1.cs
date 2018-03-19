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
    public class UserService1 : IUserService1
    {
        private readonly IEfGenericRepository<User> usersRepo;

        public UserService1(IEfGenericRepository<User> usersRepo, IMapper mapper)
        {
            this.usersRepo = usersRepo;
        }


        public void RegisterUser(string userName, string password, string phoneNumber, string firstName = null, string lastName = null)
        {
            var user = new UserModel()
            {
                Username = userName,
                Password = password,
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                LastName = lastName
            };
            var userToAdd = Mapper.Map<User>(user);
            usersRepo.Add(userToAdd);
        }
    }
}
