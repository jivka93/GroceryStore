using DTO;
using DTO.Contracts;
using System;
using System.Collections.Generic;

namespace Services.Contacts
{
    public interface IUserService
    {
        IEnumerable<IUserModel> GetAllUsers();

        IUserModel GetSpecificUser(string userName);

        IUserModel GetSpecificUser(int userId);

        void UpdatePassword(int userId, string password);

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
