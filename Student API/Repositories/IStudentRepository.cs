using Student_API.Models;

namespace Student_API.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
