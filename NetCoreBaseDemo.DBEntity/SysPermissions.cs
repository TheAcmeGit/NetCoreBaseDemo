using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheAcme.EntityModule.DbModels
{
    [Table("SysPermissions")]
    public class SysPermission
    {
        [ExplicitKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Method { get; set; }
        public string UrlLink { get; set; }
        public string ParentId { get; set; }
        public bool IsIeaf { get; set; }
        public bool IsButton { get; set; }
        public int Status { get; set; }
        public DateTimeOffset CreateTime { get; set; }

    }
}
