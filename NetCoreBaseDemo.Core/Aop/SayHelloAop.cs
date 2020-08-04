using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.Core.Aop
{
    class SayHelloAop : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("执行前");
            invocation.Proceed();
            Console.WriteLine("执行后");
        }
    }
}
