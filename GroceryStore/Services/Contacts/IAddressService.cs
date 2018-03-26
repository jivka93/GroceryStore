using DTO;

namespace Services.Contacts
{
    public interface IAddressService
    {
        AddressModel FindAddressById(int addressId);

        bool DeleteAddressById(int addressId);
    }
}
