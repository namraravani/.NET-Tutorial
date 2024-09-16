using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalExceptionHandlingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            throw new Exception("Test exception");
            return Ok(new[] { 1, 2, 3 });
        }
    }
}
