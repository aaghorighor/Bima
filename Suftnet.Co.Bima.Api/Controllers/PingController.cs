namespace Suftnet.Co.Bima.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/ping")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        [Route("ping")]
        public async Task<IActionResult> Ping()
        {        
            return Ok(await Task.Run(() => DateTime.UtcNow));
        }
    }
}
