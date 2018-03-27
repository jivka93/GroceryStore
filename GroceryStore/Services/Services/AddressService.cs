using AutoMapper;
using DAL.Contracts;
using DTO;
using Models;
using Services.Contacts;

namespace Services
{
    public class AddressService: IAddressService
    {
        private readonly IEfGenericRepository<Address> addressRepo;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public AddressService(IEfGenericRepository<Address> addressRepo, IMapper mapper, IUserService userService)
        {
            this.addressRepo = addressRepo;
            this.mapper = mapper;
            this.userService = userService;
        }

        public void AddNewAddress(string addressText, int userId)
        {
            var user = this.userService.GetSpecificUser(userId);

            AddressModel addressDTO = new AddressModel()
            {
                AddressText = addressText,
                UserId = userId
            };

            this.addressRepo.Add(this.mapper.Map<Address>(addressDTO));
        }

        public bool DeleteAddressById(int addressId)
        {
            try
            {
                var address = this.addressRepo.GetById(addressId);
                this.addressRepo.Delete(address);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }


    }
}
