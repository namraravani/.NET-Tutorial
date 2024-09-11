using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace User.Management.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        [HttpGet("employee")]

        public IEnumerable<string> Get() {
            return new List<string> {"Ahmed","Ali","Namra"};
        }
    }
}
