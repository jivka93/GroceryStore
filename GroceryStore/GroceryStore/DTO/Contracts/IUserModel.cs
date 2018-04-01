using System.Collections.Generic;

namespace DTO.Contracts
{
    public interface IUserModel
    {
        int Id { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        string PhoneNumber { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        ICollection<AddressModel> Adresses { get; set; }
        ICollection<BankCardModel> BankCards { get; set; }
        ICollection<OrderModel> Orders { get; set; }
    }
}
