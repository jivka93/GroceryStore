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

        public UserModel GetSpecificUser(int userId) //This one will be used when the user select update in "MyProfile"
        {
            return this.usersRepo.All.ProjectTo<UserModel>().Where(x => x.Id == userId).FirstOrDefault();
        }


        public bool RegisterUser(string userName, string password,string phoneNumber, string firstName = null, string lastName = null)
        {
            try
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
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public void UpdatePassword(int id, string password)
        {
            // todo - fix not saving changes in database
            var user = this.usersRepo.All.Where(x => x.Id == id).FirstOrDefault().Password = password;
            //DbContext.SaveChanges();
            //    Username = userName,
            //    Password = password,
            //    PhoneNumber = phoneNumber,
            //    FirstName = firstName,
            //    LastName = lastName
            //};
            //var userToAdd = Mapper.Map<User>(user);
            //usersRepo.Add(userToAdd);
        }
    }
}
