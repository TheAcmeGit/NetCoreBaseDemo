using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreBaseDemo.Core.IServices;
using NetCoreBaseDemo.DBEntity.Base.EnumTypes;
using NetCoreBaseDemo.DTOEntity;
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
        [HttpGet]
        public IActionResult Get(int pageIndex, int pageSize, string departmentName, string departmentStatus)
        {
            try
            {
                string where = "where 1=1 ";
                if (!string.IsNullOrWhiteSpace(departmentName))
                {
                    where += " and departmentName like @departmentName";
                }
                if (!string.IsNullOrWhiteSpace(departmentStatus))
                {
                    where += " and departmentStatus=@departmentStatus";
                }
                var data = _service.GetListPaged(pageIndex, pageSize, where, " createtime desc", new { departmentName = $"{departmentName}%", departmentStatus = departmentStatus });
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 新增部门
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(SysDepartmentDto entity)
        {
            return Ok(_service.Insert(entity));
        }
        /// <summary>
        /// 新增部门
        /// </summary>
        /// <param name="entity">部门实体对象</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(SysDepartmentDto entity)
        {
            entity.Createtime = DateTimeOffset.Now;
            return Ok(_service.Update(entity));
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id">ID标识</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(string id)
        {
            return Ok(_service.Delete(id));
        }
        /// <summary>
        /// 生成默认数据
        /// </summary>
        /// <param name="count">条数</param>
        /// <returns></returns>
        [HttpPost("{count}",Name = "LoadData")]
        public IActionResult LoadData(int count)
        {
            Enumerable.Range(1, count).Select(item => new SysDepartmentDto
            {
                Id = Guid.NewGuid().ToString(),
                //Createtime = DateTimeOffset.Now,
                DepartmentName = $"部门{item}",
                //DepartmentStatus = DepartmentStatusTypes.可用,
            }).ForAll(item =>
            {
                _service.Insert(item);
            });
            return Ok("完成");
        }
    }
}