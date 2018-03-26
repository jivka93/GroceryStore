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

        public AddressService(IEfGenericRepository<Address> addressRepo, IMapper mapper)
        {
            this.addressRepo = addressRepo;
            this.mapper = mapper;
        }

        public AddressModel FindAddressById(int addressId)
        {
            var address = this.addressRepo.GetById(addressId);
            var addressDTO = mapper.Map<AddressModel>(address);
            return addressDTO;
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
