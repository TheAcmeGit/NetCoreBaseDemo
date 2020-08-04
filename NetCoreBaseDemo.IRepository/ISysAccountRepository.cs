using NetCoreBaseDemo.DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBaseDemo.IRepository
{
    public interface ISysAccountRepository:IBaseRepository<Guid,SysAccount>
    {
    }
}
