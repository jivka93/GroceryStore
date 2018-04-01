using System;

namespace Services.Contacts
{
    public interface IBankCardService
    {
        void AddNewBankCard(string number, DateTime expDate, string holderName, int userId); 

        bool DeleteCardById(int cardId);
    }
}
