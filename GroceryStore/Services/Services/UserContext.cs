using AutoMapper;
using DAL;
using Models;
using Services.Contacts;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserContext : IUserContext
    {
        private int? loggedUserId;
        private GroceryStoreContext dbContext;
        private IMapper mapper;

        public UserContext(GroceryStoreContext dbContext, IMapper mapper) 
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public int? LoggedUserId
        {
            get => this.loggedUserId;
            private set => this.loggedUserId = value;
        }

        public void Login(int userId)
        {
            this.LoggedUserId = userId;

        }

        public void Logout()
        {
            this.LoggedUserId = null;
        }

        public User CheckLogin(string username, string password)
        {
            var user = this.dbContext.Users
                .Where(x => x.Username == username && x.Password == password)
                .FirstOrDefault();

            return user;
        }

    }
}
