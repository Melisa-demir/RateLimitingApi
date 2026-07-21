using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimitingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableRateLimiting("products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new[]
            {
                new { Id = 1, Name = "Laptop", Price = 10.0 },
                new { Id = 2, Name = "Mouse", Price = 20.0 },
                new { Id = 3, Name = "Keyboard", Price = 30.0 }
            };
            return Ok(products);
        }
    }
}
