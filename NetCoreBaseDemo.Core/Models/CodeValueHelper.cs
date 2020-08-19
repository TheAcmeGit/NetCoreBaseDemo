using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.Core.Models
{
    public class CodeValueHelper
    {
        public const int Success_ActionCode = 20000;
        public const string Success_ActionMsg = "成功";

        /// <summary>
        /// 模型验证失败
        /// </summary>
        public const int Error_Model_ValidationCode = 10001;
        public const string Error_Model_ValidationMsg = "模型验证失败";
    }
}
