using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreBaseDemo.Core.IServices;
using NetCoreBaseDemo.DBEntity;
using NetCoreBaseDemo.DBEntity.Base.RequestModel;
using NetCoreBaseDemo.DTOEntity;
using NetCoreBaseDemo.IRepository;
using NetCoreBaseDemo.IService;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SysAccountController : ControllerBase
    {


        private readonly ILogger<SysAccountController> _logger;
        private readonly ISysAccountService _service;
        private readonly IRedisMangerService _redisManger;

        public SysAccountController(ILogger<SysAccountController> logger, ISysAccountService service, IRedisMangerService redisManger)
        {
            _logger = logger;
            _service = service;
            _redisManger = redisManger;
        }
        [HttpGet]
        [ProducesResponseType(typeof(SysAccountDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(SysAccountRequest model)
        {
            try
            {
               
                    return Ok(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpGet(Name ="Get1")]
        //[ProducesResponseType(typeof(SysAccountRequest), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Get1(SysAccountRequest request)
        //{
        //    try
        //    {
        //        return Ok(request);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //[HttpGet(Name ="Get2")]
        //[ProducesResponseType(typeof(SysAccountDto), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult Get2()
        //{
        //    try
        //    {
        //        var data = _service.GetAll();
        //        return Ok(data);
               
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(SysAccount entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            return Ok(_service.Insert(entity));
        }
      
    }
}
