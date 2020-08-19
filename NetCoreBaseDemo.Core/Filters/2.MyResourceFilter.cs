using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBaseDemo.Core.Filters
{
    /// <summary>
    /// 优先级2：资源过滤器： 它在Authorzation后面运行，同时在后面的其它过滤器完成后还会执行。Resource filters 实现缓存或其它性能原因返回。因为它运行在模型绑定前，所以这里的操作都会影响模型绑定。
    /// </summary>
    public class MyResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {

        }
    }
}
