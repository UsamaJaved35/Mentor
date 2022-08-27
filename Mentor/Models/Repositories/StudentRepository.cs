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
                //var std = new Student()
                //{
                //    FirstName = model.FirstName,
                //    LastName = model.LastName,
                //    Password = model.Password,
                //    Gender = model.Gender,
                //    Education = model.Education,
                //    Address = model.Address,
                //    Country = model.Country,
                //    City = model.City,
                //    PhoneCode = model.PhoneCode,
                //    PhoneNumber = model.PhoneNumber,
                //    Email = model.Email,
                //};
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
