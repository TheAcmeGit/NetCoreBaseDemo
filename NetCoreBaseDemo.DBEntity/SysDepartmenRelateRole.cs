using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheAcme.EntityModule.DbModels
{
    [Table("SysDepartmenRelateRole")]
    public class SysDepartmenRelateRole
    {
        [ExplicitKey]
        public string Id { get; set; }
        public string SysRoleId { get; set; }
        public string SysDepartmentId { get; set; }
   
    }
}
