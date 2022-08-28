using Mentor.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Tutor_Finder.Models;

namespace Mentor.Models.Repositories
{
    public class StudentRepository: IStudent
    {
        public bool AddStudent(Student model)
        {
            using (var context = new StudentContext())
            {
                context.Students.Add(model);

                // or
                // context.Add<Student>(std);

                context.SaveChanges();
            }
            return true;
        }
       // public Student GetStudent(Login l)
        //{

 //       }
    }
}
