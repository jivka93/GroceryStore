
using Common.Mapping;
using Models;
using AutoMapper;
using System.Collections.Generic;

namespace DTO  //We create the model that will be exposed to the client through the Service/Logic
{
    public class UserModel : IMapFrom<User>  //IHaveCustomMappings  for custom mapping
    {       
        public string Username { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public ICollection<Address> Adresses { get; set; }
        public ICollection<BankCard> BankCards { get; set; }
        public ICollection<Order> Orders { get; set; }  
    }
}
