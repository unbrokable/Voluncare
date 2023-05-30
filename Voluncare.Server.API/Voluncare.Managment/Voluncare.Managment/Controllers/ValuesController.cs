using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Voluncare.Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        [Route("test")]
        public IActionResult Test123()
        {
            return Ok(new { ok = "ok" });
        }
    }
}
