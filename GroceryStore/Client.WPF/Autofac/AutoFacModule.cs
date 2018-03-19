using Autofac;
using AutoMapper;
using DAL;
using DAL.Contracts;
using DTO;
using Models;
using Services;
using Services.Contacts;

namespace Client.WPF.Autofac
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GroceryStoreContext>().AsSelf().InstancePerDependency();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerDependency();
            builder.RegisterType<UserModel>().AsSelf();
            builder.Register(x => Mapper.Instance);
            builder.RegisterType<EfGenericRepository<User>>().As<IEfGenericRepository<User>>().InstancePerDependency();
        }
    }
}
