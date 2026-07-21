using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimitingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        [EnableRateLimiting("login")]
        public IActionResult Login()
        {
            return Ok(new
            {
                Message = "Login başarılı."
            });
        }
    }
}
