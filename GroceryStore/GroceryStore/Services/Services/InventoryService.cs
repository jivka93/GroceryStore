using Bytes2you.Validation;
using Common;
using DAL.Contracts;
using Models;
using Services.Contacts;

namespace Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IEfUnitOfWork unitOfWork;
        private readonly IMappingProvider mapper;
        private readonly IEfGenericRepository<Inventory> inventories;

        public InventoryService(IEfUnitOfWork unitOfWork, IMappingProvider mapper, IEfGenericRepository<Inventory> inventories) 
        {
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();
            Guard.WhenArgument(mapper, "mapper").IsNull().Throw();
            Guard.WhenArgument(inventories, "inventories").IsNull().Throw();
            this.inventories = inventories;
        }
    }
}
