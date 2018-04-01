using AutoMapper;
using Bytes2you.Validation;
using Common;
using DAL.Contracts;
using DTO;
using Models;
using Services.Contacts;

namespace Services
{
    public class AddressService: IAddressService
    {
        private readonly IEfUnitOfWork unitOfWork;
        private readonly IMappingProvider mapper;
        private readonly IUserService userService;
        private readonly IEfGenericRepository<Address> addresses;

        public AddressService(IEfUnitOfWork unitOfWork, IMappingProvider mapper, IUserService userService, IEfGenericRepository<Address> addresses)
        {
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(addresses, "addresses").IsNull().Throw();
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userService = userService;
            this.addresses = addresses;
        }

        public void AddNewAddress(string addressText, int userId)
        {
            Guard.WhenArgument(addressText, "addressText").IsNull().Throw();
            var user = this.userService.GetSpecificUser(userId);

            AddressModel addressDTO = new AddressModel()
            {
                AddressText = addressText,
                UserId = userId
            };

            this.addresses.Add(this.mapper.Map<AddressModel, Address>(addressDTO));
            unitOfWork.SaveChanges();
        }

        public bool DeleteAddressById(int addressId)
        {
            try
            {
                var address = this.addresses.GetById(addressId);
                this.addresses.Delete(address);
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
