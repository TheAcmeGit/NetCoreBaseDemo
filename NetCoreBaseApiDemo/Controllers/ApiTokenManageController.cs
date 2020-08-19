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
            var array = Enumerable.Range(1, 10).Select(f => new TokenModel
            {
                ID = f.ToString(),
                UserName = $"Admin-{f}"
            });
            return Ok(array);
        }
    }
}