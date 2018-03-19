using DTO;
using System.Collections.Generic;

namespace Services.Contacts
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAllUsers();

        UserModel GetSpecificUser(string userName);

        void RegisterUser(string userName, string password, string phoneNumber, string firstName = null, string lastName = null);
    }
}
