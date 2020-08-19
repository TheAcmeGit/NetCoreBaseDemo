using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheAcme.EntityModule.DbModels
{
    [Table("SysAccountRelateRole")]
    public class SysAccountRelateRole
    {
        [Required]
        [ExplicitKey]
        public string Id { get; set; }
        public string SysAccountId { get; set; }
        public string SysRoleId { get; set; }
    }
}
