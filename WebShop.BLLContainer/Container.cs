using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.BLL;
using WebShop.IBLL;

namespace WebShop.BLLContainer
{

    public class Container
    {
        /// <summary>
        /// IOC容器
        /// </summary>
        public static IContainer container = null;

        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    Initialise();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("IOC实例化出错：" + ex.Message);
            }
            return container.Resolve<T>();
        }
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            //格式：builder.RegisterType<xxxx>().As<Ixxxx>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
