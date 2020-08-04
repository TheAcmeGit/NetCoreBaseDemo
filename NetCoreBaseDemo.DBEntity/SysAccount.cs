using NetCoreBaseDemo.DBEntity.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreBaseDemo.DBEntity
{
    [Table("SysAccount")]
    public class SysAccount:RootEntity
    {
        public string UserName { get; set; }
        public string Passwprd { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
