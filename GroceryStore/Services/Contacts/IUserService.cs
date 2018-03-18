using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contacts
{
    public interface IUserService
    {
        void AddUser(UserModel user);
        IEnumerable<UserModel> GetAllUsers();
        UserModel GetSpecificUser(string userName);
        void RegisterUser(string userName, string password, string phoneNumber, string firstName = null, string lastName = null);
    }
}
