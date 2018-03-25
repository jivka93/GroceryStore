using DTO;
using System;
using System.Collections.Generic;

namespace Services.Contacts
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAllUsers();

        UserModel GetSpecificUser(string userName);

        UserModel GetSpecificUser(int userId);

        void UpdatePassword(int id, string password);

        void UpdateProfileInfo(int id, string firstName = null, string lastName = null, string phone = null);

        bool RegisterUser(string userName, string password, string phoneNumber,
            string firstName = null,
            string lastName = null,
            string address = null,
            string bankCardNumber = null,
            DateTime? expDate = null,
            string cardName = null);
    }
}
