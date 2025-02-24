using Student_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Student_API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudent(int id)
        {
            return _context.Students.Find(id);
        }

        public int AddStudent(Student student)
        {
            _context.Students.Add(student);
            return _context.SaveChanges();
        }

        public int UpdateStudent(Student student)
        {
            
            if (_context.Students.Find(student.Id) != null)
            {
                _context.ClearContext();
                _context.Entry(student).State = EntityState.Modified;
                int result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

        public int DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            return _context.SaveChanges();
        }
    }
}
