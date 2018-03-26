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
            builder.RegisterType<UserContext>().As<IUserContext>().InstancePerLifetimeScope();
            builder.RegisterType<GroceryStoreContext>().As<IGroceryStoreContext>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();

            builder.Register(x => Mapper.Instance);

        }
    }
}
