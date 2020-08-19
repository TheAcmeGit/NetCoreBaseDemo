using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.Core.Models
{
    public class BaseResutlData
    {
        public int Code { get; set; } = 20000;
        public dynamic Data { get; set; }
        public string Msg { get; set; }
    }
}
