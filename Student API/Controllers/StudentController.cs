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
        public IActionResult Get()
        {
            IEnumerable<Student> students = _studentRepository.GetStudents();
            if (students.Count() == 0)
            {
                return NoContent();
            }
            return Ok(students);
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
            return Ok(student);
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            var countAdded=_studentRepository.AddStudent(student);
            if (countAdded > 0)
            {
                return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
            }
            return StatusCode(500);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            var countUpdated=_studentRepository.UpdateStudent(student);
            if (countUpdated > 0)
            {
                return NoContent();
            }
            return StatusCode(500);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var countDeleted=_studentRepository.DeleteStudent(id);
            if (countDeleted>0)
            {
                return NoContent();
            }
            return StatusCode(500);
        }
    }
}
