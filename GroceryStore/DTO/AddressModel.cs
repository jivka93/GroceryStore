using Common.Mapping;
using Models;

namespace DTO
{
    public class AddressModel : IMapFrom<Address>
    {
        public int Id { get; set; }

        public string AddressText { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
