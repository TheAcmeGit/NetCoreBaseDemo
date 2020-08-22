using NetCoreBaseDemo.DTOEntity;
using System;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.IService
{
    public interface ISysAccountService : IBaseService<string, SysAccount,SysAccountDto>
    {

    }
}
