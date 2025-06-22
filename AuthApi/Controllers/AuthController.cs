using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        [HttpGet("ping")]
        public IActionResult Ping() {
            return Ok("Pong");
        }


        [HttpPost("register")]
        public IActionResult Register(){
        }
    }
}
