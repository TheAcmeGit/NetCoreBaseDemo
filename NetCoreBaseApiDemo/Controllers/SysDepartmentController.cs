using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreBaseDemo.Core.IServices;
using NetCoreBaseDemo.IService;
using TheAcme.EntityModule.DbModels;

namespace NetCoreBaseApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SysDepartmentController : ControllerBase
    {


        private readonly ILogger<SysAccountController> _logger;
        private readonly ISysDepartmentService _service;
        private readonly IRedisMangerService _redisManger;

        public SysDepartmentController(ILogger<SysAccountController> logger, ISysDepartmentService service, IRedisMangerService redisManger)
        {
            _logger = logger;
            _service = service;
            _redisManger = redisManger;
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
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
        public IActionResult Post(SysDepartment entity)
        {
            return Ok(_service.Insert(entity));
        }
    }
}