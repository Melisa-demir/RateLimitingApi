using Microsoft.AspNetCore.Mvc;

namespace RateLimitingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemController : ControllerBase
    {
        [HttpPost]
        public IActionResult Healty()
        {
            return Ok(new
            {
                Status = "Healthy",
                Date = DateTime.UtcNow
            });
        }
    }
}
