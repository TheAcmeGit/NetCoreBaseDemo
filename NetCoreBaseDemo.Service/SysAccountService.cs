using AutoMapper;
using NetCoreBaseDemo.IRepository;
using NetCoreBaseDemo.IService;
using System;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Service
{
    public class SysAccountService : BaseService<Guid, SysAccount>, ISysAccountService
    {
        private readonly IMapper _mapper;
        private readonly ISysAccountRepository _repository;
        public SysAccountService(ISysAccountRepository repository, IMapper mapper)
        {
            base._baseRepository = repository;
            _repository = repository;
            _mapper = mapper;
        }
    }
}
