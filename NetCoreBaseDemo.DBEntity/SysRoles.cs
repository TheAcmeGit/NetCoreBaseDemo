using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheAcme.EntityModule.DbModels
{
    [Table("SysRole")]
    public class SysRole
    {
        [Required]
        [ExplicitKey]
        public string Id { get; set; }
        public string RoleName { get; set; }
        public int RoleType { get; set; }
        public int RoleLevel { get; set; }
        public string RoleDepartment { get; set; }
        public int RoleStatus { get; set; }
   
    }
}
