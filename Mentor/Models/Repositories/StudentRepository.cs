using Mentor.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Mentor.Models;

namespace Mentor.Models.Repositories
{
    public class StudentRepository : IStudent
    {
        private readonly IWebHostEnvironment Environment;
        public StudentRepository(IWebHostEnvironment environment)
        {
            Environment = environment;
        }
        public bool sendRequest(string email,int id)
        {
            var context = new StudentContext();
            Tutor t = context.Tutors.FirstOrDefault(x => x.Email == email);
            if (t != null)
            {
                Student_Tutor st = new Student_Tutor();
                st.TId = t.TId;
                st.SId = id;
                st.requestStatus = false;
                context.Add(st);
                context.SaveChanges();
                return true;
            }
            return false;
        }
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
        public string imageExists(string email)
        {
            var db = new StudentContext();
            Student myUser = db.Students.FirstOrDefault
               (u => u.Email.Equals(email));
            return myUser.ImagePath;
        }
        public bool UpdateStudent(Student s, List<IFormFile> postedFiles)
        {
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "StudentImages");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (var file in postedFiles)
            {
                var fileName = Path.GetFileName(file.FileName);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    //Console.WriteLine(stream);
                    // ViewBag.Message = "file uploaded successfully";
                }
                Console.WriteLine(s.ImagePath);
                pathWithFileName = "StudentImages/" + file.FileName;
                s.ImagePath = pathWithFileName;
            }
            using (var context = new StudentContext())
            {

                // Use of lambda expression to access
                // particular record from a database
                var data = context.Students.FirstOrDefault(x => x.Email == s.Email);

                // Checking if any such record exist
                if (data != null)
                {
                    data.FirstName = s.FirstName;
                    data.LastName=s.LastName;
                    data.Password = s.Password;
                    data.ConfirmPassword = s.ConfirmPassword;
                    data.Address = s.Address;
                    data.PhoneCode = s.PhoneCode;
                    data.PhoneNumber = s.PhoneNumber;
                    data.Country = s.Country;
                    data.City = s.City;
                    data.Gender = s.Gender;
                    data.Education = s.Education;
                    data.ImagePath = s.ImagePath;
                    var res=context.SaveChanges();
                    if (res > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            // public Student GetStudent(Login l)
            //{

            //       }
        }
    }
}
