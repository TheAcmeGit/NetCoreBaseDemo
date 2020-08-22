using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace NetCoreBaseDemo.DBEntity.Base
{
    public class ResponseTable<T>
    {
        public IEnumerable<T> TableData { get; set; }
        public int Total { get; set; }
    }
}
