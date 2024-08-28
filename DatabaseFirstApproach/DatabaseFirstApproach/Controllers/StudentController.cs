using DatabaseFirstApproach.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class StudentController(EntityFrameworkContext context) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddNewStudent([FromBody] Student student)
        {
            
            context.Students.Add(student);
            await context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpPost("Insert-bulk-students")]
        public async Task<IActionResult> AddManyNewStudent([FromBody] List<Student> students)
        {
            
            context.Students.AddRange(students);
            
            await context.SaveChangesAsync();

            return Ok(students);
        }

    }
}
