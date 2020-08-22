using NetCoreBaseDemo.DBEntity.Base.EnumTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.DTOEntity
{
   public class SysDepartmentDto
    {
        public string Id { get; set; }
        public string DepartmentName { get; set; }
        public string ParentId { get; set; }
        public DepartmentStatusTypes DepartmentStatus { get; set; }
        public DateTimeOffset Createtime { get; set; }
    }
}
