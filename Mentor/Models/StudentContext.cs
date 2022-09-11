using Microsoft.EntityFrameworkCore;
using Mentor.Models;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student_Tutor>()
                .HasOne(x => x.Student)
                .WithMany(st => st.StudentTutors)
                .HasForeignKey(si => si.SId);

            modelBuilder.Entity<Student_Tutor>()
                .HasOne(x => x.Tutor)
                .WithMany(st => st.StudentTutors)
                .HasForeignKey(ti => ti.TId);
            modelBuilder.Entity<Student_Tutor>()
                 .Property(rs => rs.requestStatus)
                 .HasDefaultValue(false);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Student_Tutor> student_Tutors { get; set; }
    }
}
