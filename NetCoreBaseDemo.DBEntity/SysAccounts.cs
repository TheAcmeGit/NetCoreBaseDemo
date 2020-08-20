using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheAcme.EntityModule.DbModels
{
    [Table("SysAccounts")]
   public class SysAccount
    {
        [Required]
        [ExplicitKey]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RealNmae { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public string IdCard { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int UserStatus { get; set; }
        public bool IsDelete { get; set; }
        public DateTimeOffset CreateTime { get; set; }
    }
}
