using AutoMapper;
using NetCoreBaseDemo.DTOEntity;
using NetCoreBaseDemo.IRepository;
using NetCoreBaseDemo.IService;
using System;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Service
{
    public class SysAccountService : BaseService<string, SysAccount, SysAccountDto>, ISysAccountService
    {
        public SysAccountService(ISysAccountRepository repository,IMapper mapper)
        {
            base._baseRepository = repository;
            base._mapper = mapper;
        }
    }
}
