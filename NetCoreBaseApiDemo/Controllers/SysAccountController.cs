using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreBaseDemo.Core.IServices;
using NetCoreBaseDemo.DBEntity;
using NetCoreBaseDemo.DTOEntity;
using NetCoreBaseDemo.IRepository;
using NetCoreBaseDemo.IService;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        [HttpGet("id")]
        [ProducesResponseType(typeof(SysAccountDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(Guid id)
        {
            try
            {
                var data = _service.Get(id);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(SysAccount entity)
        {
            entity.Id = Guid.NewGuid();
            return Ok(_service.Insert(entity));
        }
    }
}
