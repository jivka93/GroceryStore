namespace Services.Contacts
{
    public interface IAddressService
    {
        void AddNewAddress(string addressText, int userId);

        bool DeleteAddressById(int addressId);
    }
}
