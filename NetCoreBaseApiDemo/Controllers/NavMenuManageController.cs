//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using NetCoreBaseDemo.Core.IServices;
//using NetCoreBaseDemo.DBEntity;
//using NetCoreBaseDemo.IRepository;

//namespace NetCoreBaseApiDemo.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class NavMenuManageController : ControllerBase
//    {
      

//        private readonly ILogger<NavMenuManageController> _logger;
//        private readonly INavMenuRepository _repository;
//        private readonly IRedisMangerService _redisManger;

//        public NavMenuManageController(ILogger<NavMenuManageController> logger, INavMenuRepository repository, IRedisMangerService redisManger)
//        {
//            _logger = logger;
//            _repository = repository;
//            _redisManger = redisManger;
//        }
//        [HttpGet]
//        public IEnumerable<NavMenu> Get()
//        {
//            if (!_redisManger.Get("list"))
//            {
//                var data = _repository.GetAll();
//                _redisManger.Set("list", data, TimeSpan.FromSeconds(300));
//                return data;
//            }
//            else
//            {
//                var data = _redisManger.Get<IEnumerable<NavMenu>>("list");
//                return data;
//            }
//        }
//        [HttpGet("{id}")]
//        public IEnumerable<NavMenu> Get(string id)
//        {
//            if (!_redisManger.Get("list"))
//            {
//                var data = _repository.GetAll();
//                _redisManger.Set("list", data, TimeSpan.FromSeconds(300));
//                return data;
//            }
//            else
//            {
//                var data = _redisManger.Get<IEnumerable<NavMenu>>("list");
//                return data;
//            }
//        }

//        [HttpPost]
//        public string post([FromBody]NavMenu entity)
//        {
//            return _repository.Insert(entity).ToString();
//        }

//        [HttpPut]
//        public int put([FromBody]NavMenu entity)
//        {
//            return _repository.Update(entity);
//        }


//        [HttpDelete("id")]
//        public int delete(string id)
//        {
//            return _repository.Delete(id);
//        }

//    }
//}
