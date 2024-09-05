using ControllersAndMethods.Filters;
using ControllersAndMethods.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace ControllersAndMethods.Controllers
{
    [Route("[Controller]")]
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("[action]")]
        [ResourceFilter]
        public ViewResult Index()
        {
            ViewData["data1"] = "NamraRavani";
            ViewData["data2"] = 25;
            ViewData["data3"] = DateTime.Now.ToLongTimeString();
            string[] arr = { "Namra", "Ravani", "Hello", "Hiii" };
            ViewData["data4"] = arr;
            return View();
        }

        [Route("[action]")]
        public IActionResult Delete() {
            return View();
        }
        [Route("[action]")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("[action]/{id?}")]

        public int Details(int id) { 
            return id;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    
}
