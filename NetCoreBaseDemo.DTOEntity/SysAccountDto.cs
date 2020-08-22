using System;

namespace NetCoreBaseDemo.DTOEntity
{
    public class SysAccountDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
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
