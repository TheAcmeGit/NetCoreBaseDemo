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
        [Produces("application/json")]
        [ProducesResponseType(typeof(SysAccountDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int pageIndex,int pageSize,string userName)
        {
            try
            {
                string where = string.Empty;
                where = string.IsNullOrWhiteSpace(userName) ? string.Empty : $"where userName like @userName";
                var data = _service.GetListPaged(pageIndex, pageSize, where, " createtime desc",new { userName=$"{userName}%" });
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(SysAccountDto entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            entity.CreateTime = DateTimeOffset.Now;
            return Ok(_service.Insert(entity));
        }
        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult put(SysAccountDto entity)
        {
            return Ok(_service.Update(entity));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(string id)
        {
            return Ok(_service.Delete(id));
        }

    }
}
