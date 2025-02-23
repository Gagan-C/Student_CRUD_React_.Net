using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Student_API.Models;

namespace Student_API
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public bool IsDatabaseConnected()
        {
            try
            {
                return this.Database.CanConnect();
            }
            catch
            {
                return false;
            }
        }

        public bool IsStudentTableCreated()
        {
            try
            {
                return this.Database.GetService<IRelationalDatabaseCreator>().Exists() &&
                       this.Database.GetService<IRelationalDatabaseCreator>().HasTables();
            }
            catch
            {
                return false;
            }
        }
    }
}
