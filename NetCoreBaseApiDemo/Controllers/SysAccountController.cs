using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public SysAccountController(ILogger<SysAccountController> logger, ISysAccountRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<SysAccount> Get()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public Guid Post()
        {
            return _repository.Insert(new SysAccount
            {
                Id = Guid.NewGuid(),
                UserName = "Admin",
                Passwprd = "123456",
                CreateTime = DateTime.Now,
            });
        }
    }
}
