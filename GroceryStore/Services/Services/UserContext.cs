using AutoMapper;
using Bytes2you.Validation;
using DAL;
using DAL.Contracts;
using Models;
using Services.Contacts;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserContext : IUserContext
    {
        private int? loggedUserId;
        private readonly IEfGenericRepository<User> usersRepo;
        private IMapper mapper;
        private readonly IHashingPassword hashing;

        public UserContext(IEfGenericRepository<User> usersRepo, IMapper mapper, IHashingPassword hashing) 
        {
            Guard.WhenArgument(usersRepo, "userRepo").IsNull().Throw();
            Guard.WhenArgument(hashing, "hashing").IsNull().Throw();
            this.usersRepo = usersRepo;
            this.mapper = mapper;
            this.hashing = hashing;
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
            Guard.WhenArgument(username, "userName").IsNotNullOrEmpty().Throw();
            Guard.WhenArgument(password, "password").IsNotNullOrEmpty().Throw();
            var hashedPassword = hashing.GetSHA1HashData(password);

            var user = this.usersRepo.All
                .Where(x => x.Username == username && x.Password == hashedPassword)
                .FirstOrDefault();

            return user;
        }

    }
}
