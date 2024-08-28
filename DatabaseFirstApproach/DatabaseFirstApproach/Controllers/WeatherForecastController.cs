using Microsoft.AspNetCore.Mvc;
using DatabaseFirstApproach.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstApproach.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class GetEmployeeController : ControllerBase
    {


        private readonly ILogger<GetEmployeeController> _logger;
        private readonly EntityFrameworkContext context;

        public GetEmployeeController(ILogger<GetEmployeeController> logger, EntityFrameworkContext context)
        {
            _logger = logger;
            this.context = context;

        }

        [HttpGet(Name = "GetEmployeeDetail")]
        public IEnumerable<Employee> GetEmployee()
        {
            return context.Employees.ToList();
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] int id)
        {
            var result = await context.Employees.FindAsync(id);
            return Ok(result);
        }

        [HttpGet("{Designation}")]

        public async Task<IActionResult> GetEmployeeByNameAsync([FromRoute] string Designation)
        {
            var result = await context.Employees.Where(x => x.Designation == Designation).ToListAsync();
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetEmployeeByMultipleIdAsync()
        {
            List<int> list = [ 1, 2, 3 ];
            var result = context.Employees.Where(x => list.Contains(x.Id));
            return Ok(result);
        }

        [HttpGet("allEmployee")]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {

            var result = await (from emp in context.Employees select new Employee(){ Designation = emp.Designation, Name = emp.Name }) 
            .ToListAsync();
            return Ok(result);
        }


        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
