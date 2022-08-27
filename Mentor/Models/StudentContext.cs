using Microsoft.EntityFrameworkCore;
using Tutor_Finder.Models;

namespace Mentor.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(){}
        public StudentContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Mentor");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }

    }
}
