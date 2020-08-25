using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreBaseDemo.Core.IServices;
using NetCoreBaseDemo.DTOEntity;
using NetCoreBaseDemo.IService;
using AutoMapper.Internal;


namespace NetCoreBaseApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SysNavMenuController : ControllerBase
    {

        private readonly ILogger<SysNavMenuController> _logger;
        private readonly ISysNavMenuService _service;
        private readonly IRedisMangerService _redisManger;

        public SysNavMenuController(ILogger<SysNavMenuController> logger, ISysNavMenuService service, IRedisMangerService redisManger)
        {
            _logger = logger;
            _service = service;
            _redisManger = redisManger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //string where = "where 1=1 ";
                //if (!string.IsNullOrWhiteSpace(departmentName))
                //{
                //    where += " and departmentName like @departmentName";
                //}
                //if (!string.IsNullOrWhiteSpace(departmentStatus))
                //{
                //    where += " and departmentStatus=@departmentStatus";
                //}
                //var data = _service.GetListPaged(pageIndex, pageSize, where, " createtime desc", new { departmentName = $"{departmentName}%", departmentStatus = departmentStatus });


                var data = _service.GetNavMenuTreeInfo("0");
                
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
        public IActionResult Post(SysNavMenuDto entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            entity.CreateTime = DateTimeOffset.Now;
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
        public IActionResult Put(SysNavMenuDto entity)
        {
            entity.CreateTime = DateTimeOffset.Now;
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
        [HttpPost("{count}", Name = "PermissionLoadData")]
        public IActionResult PermissionLoadData(int count)
        {
            Enumerable.Range(1, count).Select(item => new SysNavMenuDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = $"{item}",
                IsLeaf = false,
        

            }).ForAll(item =>
            {
                var mod1 = new SysNavMenuDto
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"{item.Name}-1",
                    ParentId = item.Id,
                    IsLeaf = true,
              

                };
                var mod2 = new SysNavMenuDto
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"{item.Name}-2",
                    ParentId = item.Id,
                    IsLeaf = true,
                };
                _service.Insert(mod1);
                _service.Insert(mod2);
                _service.Insert(item);
            });
            return Ok("完成");
        }
    }
}