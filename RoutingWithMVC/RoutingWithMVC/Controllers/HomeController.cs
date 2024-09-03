using Microsoft.AspNetCore.Mvc;
using RoutingWithMVC.Models;
using System.Diagnostics;

namespace RoutingWithMVC.Controllers
{

    [Route("[Controller]")]
    public class HomeController : Controller
    {
        [Route("[action]")]

        public IActionResult Index()
        {
            return View();
        }

        [Route("About/{id}")]
        public int About(int id) {
            
            return id;
        }

        [Route("[action]")]
        public string Display()
        {
            return "Hello Namra";
        }

       
    }
}
