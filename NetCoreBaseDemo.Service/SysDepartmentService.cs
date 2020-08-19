using AutoMapper;
using NetCoreBaseDemo.IRepository;
using NetCoreBaseDemo.IService;
using System;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Service
{
    public class SysDepartmentService : BaseService<string, SysDepartment>, ISysDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly ISysDepartmentRepository _repository;
        public SysDepartmentService(ISysDepartmentRepository repository, IMapper mapper)
        {
            base._baseRepository = repository;
            _repository = repository;
            _mapper = mapper;
        }
    }
}
