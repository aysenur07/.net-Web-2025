using System.Net.WebSockets;
using ExampleApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ExampleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static readonly List<Student> students = new ()
        {
            new Student { Id = 1, Name = "Alice" },
            new Student { Id = 2, Name = "Bob" },
            new Student { Id = 3, Name = "Charlie" }
        };

        [HttpGet]
        public IActionResult GetStudents()
        {
          return Ok(students);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            var newId=students.Any()? students.Max(s => s.Id) + 1 : 1;
            student.Id = newId;
            students.Add(student);
            return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, student);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}
