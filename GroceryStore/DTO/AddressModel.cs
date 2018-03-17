using Common.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AddressModel : IMapFrom<Address>
    {
        public int Id { get; set; }

        public string AddressText { get; set; }



    }
}
