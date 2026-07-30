using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightPal.Controllers
{
    [Route("test")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get() {

            return Ok(new { name = "Juan", apellido="Perez"});
        }
    }
}
