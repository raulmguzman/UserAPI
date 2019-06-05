using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using UserAPI.Domain;
using UserAPI.Services;

namespace UserAPI.Map
{
    public class ServicesModules: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UsersService>().As<IUsersService>();
            builder.RegisterType<UsersDomain>().As<IUsersDomain>();
        }
    }
}
