using Microsoft.AspNetCore.Mvc;
using Student_API.Models;
using Student_API.Repositories;

namespace Student_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentRepository.GetStudents();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = _studentRepository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            _studentRepository.AddStudent(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _studentRepository.UpdateStudent(student);
            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentRepository.DeleteStudent(id);
            return NoContent();
        }
    }
}
