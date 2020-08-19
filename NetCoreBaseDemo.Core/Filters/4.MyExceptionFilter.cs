using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBaseDemo.Core.Filters
{
    /// <summary>
    /// 优先级4：异常过滤器：被应用全局策略处理未处理的异常发生前异常被写入响应体
    /// </summary>
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

        }
    }
}
