﻿using Autofac;
using AutoMapper;
using Common;
using DAL;
using DAL.Contracts;
using DTO;
using DTO.Contracts;
using Json.Reader;
using Models;
using Services;
using Services.Contacts;
using Services.Services;

namespace Client.WPF.Autofac
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Data
            builder.RegisterType<GroceryStoreContext>().AsSelf().SingleInstance();
            builder.RegisterType<EfUnitOfWork>().As<IEfUnitOfWork>().InstancePerDependency();
            
            // Services
            builder.RegisterType<UserContext>().As<IUserContext>().SingleInstance();
            builder.RegisterType<ShoppingCart>().As<IShoppingCart>().SingleInstance();
            builder.RegisterType<HashingPassword>().As<IHashingPassword>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerDependency();
            builder.RegisterType<AddressService>().As<IAddressService>().InstancePerDependency();
            builder.RegisterType<BankCardService>().As<IBankCardService>().InstancePerDependency();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerDependency();
            builder.RegisterType<InventoryService>().As<IInventoryService>().InstancePerDependency();

            // Repositories
            builder.RegisterType<EfGenericRepository<User>>().As<IEfGenericRepository<User>>().InstancePerDependency();
            builder.RegisterType<EfGenericRepository<Product>>().As<IEfGenericRepository<Product>>().InstancePerDependency();
            builder.RegisterType<EfGenericRepository<Address>>().As<IEfGenericRepository<Address>>().InstancePerDependency();
            builder.RegisterType<EfGenericRepository<BankCard>>().As<IEfGenericRepository<BankCard>>().InstancePerDependency();
            builder.RegisterType<EfGenericRepository<Order>>().As<IEfGenericRepository<Order>>().InstancePerDependency();
            builder.RegisterType<EfGenericRepository<Inventory>>().As<IEfGenericRepository<Inventory>>().InstancePerDependency();

            // DTO Models
            builder.RegisterType<UserModel>().As<IUserModel>();

            // Common
            builder.Register(x => Mapper.Instance);
            builder.RegisterType<MappingProvider>().As<IMappingProvider>().SingleInstance();
            builder.RegisterType<JsonFilesReader>().AsSelf().SingleInstance();

        }
    }
}
