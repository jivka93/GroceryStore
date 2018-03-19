using AutoMapper;
using DAL.Contracts;
using Models;
using Services.Contacts;
using System.Linq;

namespace Services
{
    public class UserContext : BaseService, IUserContext
    {
        private int? loggedUserId;

        public UserContext(IGroceryStoreContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
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
            var user = base.DbContext.Users
                .Where(x => x.Username == username && x.Password == password)
                .FirstOrDefault();

            return user;
        }
    }
}
