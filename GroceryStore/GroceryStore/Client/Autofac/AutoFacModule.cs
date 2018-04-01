using Autofac;
using AutoMapper;
using DAL;
using DAL.Contracts;
using Models;
using Services;
using Services.Contacts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Autofac
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GroceryStoreContext>().AsSelf().InstancePerDependency();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerDependency();
            builder.Register(x => Mapper.Instance);

            builder.RegisterType<EfGenericRepository<User>>().As<IEfGenericRepository<User>>().InstancePerDependency();

        }
    }
}
