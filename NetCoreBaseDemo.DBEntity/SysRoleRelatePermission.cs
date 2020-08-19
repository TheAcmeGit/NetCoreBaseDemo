using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheAcme.EntityModule.DbModels
{
    [Table("SysRoleRelatePermission")]
    public  class SysRoleRelatePermission
    {
        [Required]
        [ExplicitKey]
        public string Id { get; set; }
        public string SysPermissionId { get; set; }
        public string SysRoleId { get; set; }

     
    }
}
