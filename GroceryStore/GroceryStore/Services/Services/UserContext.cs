using Bytes2you.Validation;
using Common;
using DAL.Contracts;
using Models;
using Services.Contacts;
using System.Linq;

namespace Services
{
    public class UserContext : IUserContext
    {
        private int? loggedUserId;
        private IMappingProvider mapper;
        private readonly IHashingPassword hashing;
        private readonly IEfUnitOfWork unitOfWork;
        private readonly IEfGenericRepository<User> users;

        public UserContext(IMappingProvider mapper, IHashingPassword hashing, IEfUnitOfWork unitOfWork, IEfGenericRepository<User> users) 
        {
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();
            Guard.WhenArgument(hashing, "hashing").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();
            Guard.WhenArgument(users, "users").IsNull().Throw();
            this.mapper = mapper;
            this.hashing = hashing;
            this.unitOfWork = unitOfWork;
            this.users = users;
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
            Guard.WhenArgument(username, "userName").IsNull().Throw();
            Guard.WhenArgument(password, "password").IsNull().Throw();
            Guard.WhenArgument(username, "userName").IsEmpty().Throw();
            Guard.WhenArgument(password, "password").IsEmpty().Throw();

            var hashedPassword = hashing.GetSHA1HashData(password);

            var user = this.users.All
                .Where(x => x.Username == username && x.Password == hashedPassword)
                .FirstOrDefault();

            return user;
        }

    }
}
