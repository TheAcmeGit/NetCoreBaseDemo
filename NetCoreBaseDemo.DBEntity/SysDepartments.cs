using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheAcme.EntityModule.DbModels
{
    [Table("SysDepartments")]
    public class SysDepartment
    {
        [Required]
        [ExplicitKey]
        public string Id { get; set; }
        [Required(ErrorMessage = "必须")]
        [MinLength(10,ErrorMessage ="10个字节")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage ="必须")]
        public string ParentId { get; set; }
        public int DepartmentStatus { get; set; }
        public DateTimeOffset Createtime { get; set; }
    }
}
