using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCoreBaseDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreBaseDemo.Core.Filters
{
    /// <summary>
    /// 优先级3：方法过滤器：它会在执行Action方法前后被调用。这个可以在方法中用来处理传递参数和处理方法返回结果。
    /// </summary>
    public class MyActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

            if (context.Result != null)
            {
                var obj = context.Result as ObjectResult;
                BaseResutlData resultData = new BaseResutlData
                {
                    Code = CodeValueHelper.Success_ActionCode,
                    Data = obj.Value,
                    Msg = CodeValueHelper.Success_ActionMsg
                };
                context.Result = new ObjectResult(resultData);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //如果模型验证失败
            if (!context.ModelState.IsValid)
            {
                var data = context.ModelState.Select(f => new ModelValidationError
                {
                    Field = f.Key,
                    ErrorMsg = string.Join('|', f.Value.Errors.Select(ff => ff.ErrorMessage))
                });
                context.Result = new ObjectResult(new BaseResutlData
                {
                    Code = CodeValueHelper.Error_Model_ValidationCode,
                    Data = data,
                    Msg = CodeValueHelper.Error_Model_ValidationMsg
                });
            }

        }
    }

}