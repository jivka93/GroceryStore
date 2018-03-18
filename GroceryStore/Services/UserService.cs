using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Contracts;
using DTO;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserService : BaseService
    {

        public UserService(IGroceryStoreContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public void AddUser(UserModel user)
        {
            var userToAdd = base.Mapper.Map<User>(user);  //map from userModel to user type

            base.DbContext.Users.Add(userToAdd);
            base.DbContext.SaveChanges();
        }
        public IEnumerable<UserModel> GetAllUsers()  // We will use this one to check if the inputed username and password match.
        {
            return base.DbContext.Users.ProjectTo<UserModel>();
        }

        public UserModel GetSpecificUser(string userName) //This one will be used to visualize when the user select "MyProfile"
        {
            return base.DbContext.Users.ProjectTo<UserModel>().Where(x => x.Username == userName).FirstOrDefault();
        }

        public void RegisterUser(string userName, string password,string phoneNumber, string firstName = null, string lastName = null)
        {
            //var user = new UserModel()
            //{
            //    Username = userName,
            //    Password = password,
            //    PhoneNumber = phoneNumber,
            //    FirstName = firstName,
            //    LastName = lastName
            //};
            var user = new UserModel()
            {
                Username = userName,
                Password = password,
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                LastName = lastName
            };

            var userToAdd = Mapper.Map<User>(user);
            DbContext.Users.Add(userToAdd);
        }

    }
}
