using NetCoreBaseDemo.DTOEntity;
using System;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.IService
{
    public interface ISysDepartmentService : IBaseService<string, SysDepartment, SysDepartmentDto>
    {

    }
}
