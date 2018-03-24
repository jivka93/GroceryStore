using Autofac;
using AutoMapper;
using DAL;
using DAL.Contracts;
using DTO;
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
            builder.RegisterType<GroceryStoreContext>().AsSelf().InstancePerDependency();

            // Services
            builder.RegisterType<UserContext>().As<IUserContext>().SingleInstance();
            builder.RegisterType<ShoppingCart>().As<IShoppingCart>().SingleInstance();

            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerDependency();

            builder.RegisterType<HashingPassword>().As<IHashingPassword>().SingleInstance();

            //DTO Models
            builder.RegisterType<UserModel>().AsSelf();

            builder.Register(x => Mapper.Instance);

            builder.RegisterType<EfGenericRepository<User>>().As<IEfGenericRepository<User>>().InstancePerDependency();
            builder.RegisterType<EfGenericRepository<Product>>().As<IEfGenericRepository<Product>>().InstancePerDependency();
        }
    }
}
