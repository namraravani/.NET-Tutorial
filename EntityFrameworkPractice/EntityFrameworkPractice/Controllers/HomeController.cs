using EntityFrameworkPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EntityFrameworkPractice.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly StudentDBContext studentDB;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(StudentDBContext studentDB) {
            this.studentDB = studentDB;
        }
        public async Task<IActionResult> Index()
        {
            var students = await studentDB.Students.ToListAsync();
            
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if(ModelState.IsValid)
            {
                await studentDB.Students.AddAsync(std);
                await studentDB.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public async  Task<IActionResult> Details(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = await studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);

            if(stdData == null) return NotFound();
            return View(stdData);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = await studentDB.Students.FindAsync(id);

            if (stdData == null) return NotFound();
            return View(stdData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id,Student std)
        {
            if (id != std.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                studentDB.Update(std);
                await studentDB.SaveChangesAsync();
                return RedirectToAction("Index","Home");
                
            }

            return View(studentDB);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = await studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (stdData == null) return NotFound();
            return View(stdData);
        }


        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            
            
            var stdData = await studentDB.Students.FindAsync(id);

            if(stdData != null)
            {
                studentDB.Students.Remove(stdData);
                await studentDB.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(studentDB);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
