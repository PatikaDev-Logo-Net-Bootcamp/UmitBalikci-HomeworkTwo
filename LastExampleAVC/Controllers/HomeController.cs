using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastExampleAVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }

        [HttpGet]
        [Route("AppVersionControl")]
        public IActionResult GetAppVersionControl()
        {
            return Ok();
        }
        [HttpPost]
        [Route("PostAppversion")]
        public IActionResult PostAppversion()
        {
            return Ok();

        }
        [HttpPut]
        [Route("PutAppversion")]
        public IActionResult PutAppversion()
        {
            return Ok();

        }
        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("hidden")]
        public IActionResult DeleteAppVersion()
        {
            return BadRequest();

        }
    }
}
