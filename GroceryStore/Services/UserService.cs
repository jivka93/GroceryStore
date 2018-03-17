using AutoMapper;
using DAL.Contracts;
using DTO;
using Models;
using System.Collections.Generic;

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
            var userToAdd = this.mapper.Map<User>(user);

            this.dbContext.Users.Add(userToAdd);
            this.dbContext.SaveChanges();
        }
        public IEnumerable<UserModel> GetAllUsers()
        {
            return this.dbContext.Users.ProjectTo
        }


    }
}
