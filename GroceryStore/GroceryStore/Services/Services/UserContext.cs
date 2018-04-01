using AutoMapper;
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
        private IMapper mapper;
        private readonly IHashingPassword hashing;
        private readonly IEfUnitOfWork unitOfWork;
        private readonly IEfGenericRepository<User> users;

        public UserContext(IMapper mapper, IHashingPassword hashing, IEfUnitOfWork unitOfWork, IEfGenericRepository<User> users) 
        {
            Guard.WhenArgument(hashing, "hashing").IsNull().Throw();
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
            Guard.WhenArgument(username, "userName").IsNullOrEmpty().Throw();
            Guard.WhenArgument(password, "password").IsNullOrEmpty().Throw();
            var hashedPassword = hashing.GetSHA1HashData(password);

            var user = this.users.All
                .Where(x => x.Username == username && x.Password == hashedPassword)
                .FirstOrDefault();

            return user;
        }

    }
}
