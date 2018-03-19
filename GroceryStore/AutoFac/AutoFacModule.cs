using Autofac;
using AutoMapper;
using DAL;
using DAL.Contracts;
using Services;
using Services.Contacts;

namespace AutoFac
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GroceryStoreContext>().As<IGroceryStoreContext>().InstancePerDependency();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerDependency();

            builder.RegisterType<UserContext>().As<IUserContext>().SingleInstance();

            builder.Register(x => Mapper.Instance);

        }
    }
}
