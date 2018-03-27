using AutoMapper;
using DAL.Contracts;
using DTO;
using Models;
using Services.Contacts;

namespace Services
{
    public class AddressService: IAddressService
    {
        private readonly IEfUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public AddressService(IEfUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            this.unitOfWork = unitOfWork;
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

            unitOfWork.Addresses.Add(this.mapper.Map<Address>(addressDTO));
            unitOfWork.SaveChanges();

        }

        public bool DeleteAddressById(int addressId)
        {
            try
            {
                var address = this.unitOfWork.Addresses.GetById(addressId);
                unitOfWork.Addresses.Delete(address);
                unitOfWork.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }


    }
}
