using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreBaseDemo.Core.IServices;
using NetCoreBaseDemo.DBEntity;
using NetCoreBaseDemo.IRepository;

namespace NetCoreBaseApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SysAccountController : ControllerBase
    {


        private readonly ILogger<SysAccountController> _logger;
        private readonly ISysAccountRepository _repository;
        private readonly IRedisMangerService _redisManger;

        public SysAccountController(ILogger<SysAccountController> logger, ISysAccountRepository repository, IRedisMangerService redisManger)
        {
            _logger = logger;
            _repository = repository;
            _redisManger = redisManger;
        }
        [HttpGet]
        public IEnumerable<SysAccount> Get()
        {

            if (!_redisManger.Get("list"))
            {
                var data = _repository.GetAll();
                _redisManger.Set("list", data, TimeSpan.FromSeconds(300));
                return data;
            }
            else
            {
                var data = _redisManger.Get<IEnumerable<SysAccount>>("list");
                return data;
            }




        }

        [HttpPost]
        public Guid Post()
        {
            return _repository.Insert(new SysAccount
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Admin",
                Passwprd = "123456",
                CreateTime = DateTime.Now,
            });
        }
    }
}
