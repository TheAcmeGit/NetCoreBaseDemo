﻿using NetCoreBaseDemo.DTOEntity;
using System;
using System.Collections.Generic;
using System.Text;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseDemo.Core
{
    public class MapperProfiles : AutoMapper.Profile
    {
        public MapperProfiles()
        {
            CreateMap<SysAccount, SysAccountDto>().ReverseMap();
            CreateMap<SysAccountDto, SysAccount>().ReverseMap();
            CreateMap<SysDepartment, SysDepartmentDto>().ReverseMap();
            CreateMap<SysDepartmentDto, SysDepartment>().ReverseMap();
            CreateMap<SysNavMenuDto, SysNavMenu>().ReverseMap();
            CreateMap<SysNavMenu, SysNavMenuDto>().ReverseMap();
        }
    }
}
