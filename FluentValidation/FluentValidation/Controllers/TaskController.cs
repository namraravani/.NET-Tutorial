using FluentValidation.Models;
using FluentValidationDemo.Models;
using Microsoft.AspNetCore.Mvc;


namespace FluentValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public TaskController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
       
        public Taskitem Post(Taskitem task)
        {
            return task;
        }
    }
}
