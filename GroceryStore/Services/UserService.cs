using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Contracts;
using DTO;
using Models;
using Services.Contacts;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserService : IUserService
    {

        private readonly IEfGenericRepository<User> usersRepo;

        public UserService(IEfGenericRepository<User> usersRepo, IMapper mapper)
        {
            this.usersRepo = usersRepo;
        }

        public IEnumerable<UserModel> GetAllUsers()  // We will use this one to check if the inputed username and password match.
        {
            return this.usersRepo.All.ProjectTo<UserModel>();
        }

        public UserModel GetSpecificUser(string userName) //This one will be used to visualize when the user select "MyProfile"
        {
            return this.usersRepo.All.ProjectTo<UserModel>().Where(x => x.Username == userName).FirstOrDefault();
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
