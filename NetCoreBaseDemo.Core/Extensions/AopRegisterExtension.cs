using Autofac;
using Autofac.Extras.DynamicProxy;
using NetCoreBaseDemo.Core.Aop;
using NetCoreBaseDemo.Core.IServices;
using NetCoreBaseDemo.Core.Services;
using NetCoreBaseDemo.Dapper.Repository;
using NetCoreBaseDemo.IRepository;
using NetCoreBaseDemo.IService;
using NetCoreBaseDemo.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.Core.Extensions
{
    public static class AopRegisterExtension
    {
        public static ContainerBuilder AopRegister(this ContainerBuilder builder)
        {

            builder.RegisterType(typeof(SayHelloAop));
            builder.RegisterType<SysDepartmentRepository>().As<ISysDepartmentRepository>().InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(SayHelloAop));
            builder.RegisterType<SysAccountRepository>().As<ISysAccountRepository>().InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(SayHelloAop));
            builder.RegisterType<SysAccountService>().As<ISysAccountService>().InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(SayHelloAop));
            builder.RegisterType<SysDepartmentService>().As<ISysDepartmentService>().InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(SayHelloAop));

            builder.RegisterType<RedisManagerService>().As<IRedisMangerService>().InstancePerLifetimeScope();

            return builder;
        }
    }
}
