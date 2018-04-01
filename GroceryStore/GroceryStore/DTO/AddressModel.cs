using Common.Mapping;
using DTO.Contracts;
using Models;

namespace DTO
{
    public class AddressModel : IMapFrom<Address>, IAddressModel
    {
        public int Id { get; set; }

        public string AddressText { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
