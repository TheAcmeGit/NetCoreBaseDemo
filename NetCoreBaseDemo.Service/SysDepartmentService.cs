using AutoMapper;
using NetCoreBaseDemo.DTOEntity;
using NetCoreBaseDemo.IRepository;
using NetCoreBaseDemo.IService;
using System;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Service
{
    public class SysDepartmentService : BaseService<string, SysDepartment, SysDepartmentDto>, ISysDepartmentService
    {
        public SysDepartmentService(ISysDepartmentRepository repository, IMapper mapper)
        {
            base._baseRepository = repository;
            base. _mapper = mapper;
        }
    }
}
