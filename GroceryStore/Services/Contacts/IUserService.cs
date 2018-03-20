using DTO;
using System.Collections.Generic;

namespace Services.Contacts
{
    public interface IUserService
    {
        void AddUser(UserModel user);

        IEnumerable<UserModel> GetAllUsers();

        UserModel GetSpecificUser(string userName);

        UserModel GetSpecificUser(int userId);

        void UpdatePassword(int id, string password);

        bool RegisterUser(string userName, string password, string phoneNumber, string firstName = null, string lastName = null);
    }
}
