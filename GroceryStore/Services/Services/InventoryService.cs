using AutoMapper;
using DAL.Contracts;
using Models;
using Services.Contacts;

namespace Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IEfGenericRepository<Inventory> inventories;

        public InventoryService(IEfUnitOfWork unitOfWork, IMapper mapper, IEfGenericRepository<Inventory> inventories) 
        {
            this.inventories = inventories;
        }
    }
}
