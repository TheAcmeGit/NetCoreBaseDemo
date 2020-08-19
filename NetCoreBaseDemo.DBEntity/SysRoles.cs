using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheAcme.EntityModule.DbModels
{
    public class SysRoles
    {
        [ExplicitKey]
        public string Id { get; set; }
        public string RoleName { get; set; }
        public int RoleType { get; set; }
        public int RoleLevel { get; set; }
        public string RoleDepartment { get; set; }
        public int RoleStatus { get; set; }
   
    }
}
