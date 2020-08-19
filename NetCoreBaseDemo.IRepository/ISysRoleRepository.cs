using System;
using System.Collections.Generic;
using System.Text;
using TheAcme.EntityModule;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.IRepository
{
    public interface ISysRoleRepository : IBaseRepository<string, SysRole>
    {
    }
}
