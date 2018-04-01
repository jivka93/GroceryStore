using Common.Mapping;
using DTO.Contracts;
using Models;
using System.Collections.Generic;

namespace DTO
{
    public class UserModel : IMapFrom<User>, IUserModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public ICollection<AddressModel> Adresses { get; set; }
        public ICollection<BankCardModel> BankCards { get; set; }
        public ICollection<OrderModel> Orders { get; set; }  
    }
}
