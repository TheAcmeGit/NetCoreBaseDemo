using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreBaseDemo.Core.JwtHelper;

namespace NetCoreBaseApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTokenManageController : ControllerBase
    {
        public ApiTokenManageController()
        {

        }
        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            var token = TokenHelper.GetJWT(new TokenModel
            {
                ID = "1001",
                UserName = "Admin"
            });
            return Ok(token);
        }
        [Authorize]
        [HttpGet("id")]
        [ProducesResponseType(typeof(IEnumerable<TokenModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(string id="")
        {
            var obj= new
            {
                code = 20000,
                introduction = "I am a super administrator",
                avatar = "https://wpimg.wallstcn.com/f778738c-e4f8-4870-b634-56703b4acafe.gif",
                name = "Super Admin"
            };
            return Ok(obj);
        }
    }
}