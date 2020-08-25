using AutoMapper;
using NetCoreBaseDemo.DTOEntity;
using NetCoreBaseDemo.IRepository;
using NetCoreBaseDemo.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using TheAcme.EntityModule.DbModels;


namespace NetCoreBaseDemo.Service
{
    public class SysNavMenuService : BaseService<string, SysNavMenu, SysNavMenuDto>, ISysNavMenuService
    {
        public SysNavMenuService(ISysNavMenuRepository repository, IMapper mapper)
        {
            base._baseRepository = repository;
            base. _mapper = mapper;
        }

        public IEnumerable<SysNavMenuDto> GetNavMenuTreeInfo(string parentId)
        {
            var navMenus = _baseRepository.GetAll();
            var navMenuDtos = _mapper.Map<IEnumerable<SysNavMenu>, IEnumerable<SysNavMenuDto>>(navMenus);
            var returnData = new List<SysNavMenuDto>();

            var dic = navMenuDtos.Distinct().ToDictionary(key => key.Id, val => val);
            foreach (var item in dic.Values)
            {
                if (dic.ContainsKey(item.ParentId))
                {
                    dic[item.ParentId].Children.Add(item);
                }
            }

            return new[] { dic[parentId] };
        }
    }

}
