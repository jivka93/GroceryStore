using Autofac;
using AutoMapper;
using DAL;
using DAL.Contracts;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GroceryStoreContext>().As<IGroceryStoreContext>().InstancePerDependency();
            builder.RegisterType<UserService>().As<IPostService>().InstancePerDependency();

            builder.Register(x => Mapper.Instance);
        }
    }
}
