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
            builder.RegisterType<UserContext>().As<IUserContext>().InstancePerDependency();
            builder.RegisterType<GroceryStoreContext>().As<IGroceryStoreContext>().InstancePerDependency();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerDependency();

            builder.Register(x => Mapper.Instance);

        }
    }
}
