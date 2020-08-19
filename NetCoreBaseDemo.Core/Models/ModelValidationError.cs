using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.Core.Models
{
    /// <summary>
    /// 模型验证失败
    /// </summary>
    public class ModelValidationError
    {
        public string Field { get; set; }
        public string ErrorMsg { get; set; }
    }
}
