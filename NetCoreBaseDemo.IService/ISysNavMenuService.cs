using NetCoreBaseDemo.DTOEntity;
using System;
using System.Collections.Generic;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.IService
{
    public interface ISysNavMenuService : IBaseService<string, SysNavMenu, SysNavMenuDto>
    {
        IEnumerable<SysNavMenuDto> GetNavMenuTreeInfo(string parentId);
    }
}
