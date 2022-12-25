using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Project.Core.Utilities.Interceptors;
using TodoIstProject.Business.Abstract;
using TodoIstProject.Business.Concrete;
using TodoIstProject.DataAccess.Abstract;
using TodoIstProject.DataAccess.Concrete;
using Module = Autofac.Module;

namespace TodoIstProject.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TodoIstManager>().As<ITodoIstService>();
            builder.RegisterType<EfTodoIstDal>().As<ITodoIstDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<RoleManager>().As<IRoleService>();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>().SingleInstance();

            builder.RegisterType<LoginManager>().As<ILoginService>();
            builder.RegisterType<EfLoginDal>().As<ILoginDal>().SingleInstance();
        }
    }
}
