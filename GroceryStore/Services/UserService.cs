using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Contracts;
using DTO;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserService
    {
        private readonly IGroceryStoreContext dbContext;
        private readonly IMapper mapper;

        public UserService(IGroceryStoreContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddUser(UserModel user)
        {
            var userToAdd = this.mapper.Map<User>(user);  //map from userModel to user type

            this.dbContext.Users.Add(userToAdd);
            this.dbContext.SaveChanges();
        }
        public IEnumerable<UserModel> GetAllUsers()  // We will use this one to check if the inputed username and password match.
        {
            return this.dbContext.Users.ProjectTo<UserModel>();
        }

        public UserModel GetSpecificUser(string userName)
        {
            return this.dbContext.Users.ProjectTo<UserModel>()
                .Where(x => x.Username == userName).FirstOrDefault();
        }


    }
}
