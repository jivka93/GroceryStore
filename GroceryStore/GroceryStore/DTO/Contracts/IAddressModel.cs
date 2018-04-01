using Models;

namespace DTO.Contracts
{
    public interface IAddressModel
    {
        int Id { get; set; }

        string AddressText { get; set; }

        int UserId { get; set; }

        User User { get; set; }
    }
}
