using Castle.DynamicProxy;
using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBaseDemo.Core.Aop
{
    public class MiniporfilerAop : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {

            using (MiniProfiler.Current.Step("InitUser"))
            {
                invocation.Proceed();
            }
        }
    }
}
