﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBaseDemo.Core.Filters
{
    /// <summary>
    /// 优先级5：结果过滤器：它可以在执行Action结果之前执行，且执行Action成功后执行，使用逻辑必须围绕view或格式化执行结果。
    /// </summary>
    public class MyResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {

        }
    }
}
