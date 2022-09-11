using Mentor.Models.Interfaces;
using Mentor.Models;
using System.Diagnostics;
namespace Mentor.Models.Repositories
{
    public class TutorRepository : ITutor
    {
        private readonly IWebHostEnvironment Environment;
        public TutorRepository(IWebHostEnvironment environment)
        {
            Environment = environment;
        }
        public int getIdByEmail(string email)
        {
            var context = new StudentContext();
            Tutor t = context.Tutors.FirstOrDefault(x => x.Email == email);
            return t.TId;
        }
        public List<Tutor> GetAllTutors()
        {
            var context = new StudentContext();
            var allTutors =context.Tutors.Select(x => x).Where(x=>x.Status==true).ToList();
            return allTutors;
        }
        public List<Student> SeeRequests(string id)
        {
            var context = new StudentContext();
            List<Student_Tutor> st = new List<Student_Tutor>();
            List<int> sList = new List<int>();
            st = context.student_Tutors.Select(x => x).Where(x => x.TId == int.Parse(id)
            && x.requestStatus==false).ToList();
            foreach( Student_Tutor student in st)
            {
                sList.Add(student.SId);
            }
            var l = context.Students.Where(t => sList.Contains(t.SId)).ToList();
            return l;
        }
        public bool requestStatus(bool status,int id)
        {
            var context = new StudentContext();
            if (status)
            {
                var data = context.student_Tutors.FirstOrDefault(x => x.SId == id);
                data.requestStatus = true;
            }
            else
            {
                var itemToRemove = context.student_Tutors.SingleOrDefault(x => x.SId == id); //returns a single item.

                if (itemToRemove != null)
                {
                    context.student_Tutors.Remove(itemToRemove);
                }
            }
            var res = context.SaveChanges();
            if (res > 0)
                return true;
            else
                return false;
        }
        public bool AddTutor(Tutor t, List<IFormFile> postedFiles)
        {
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "Uploads");
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
                    Console.WriteLine(stream);
                    // ViewBag.Message = "file uploaded successfully";
                }
                Console.WriteLine(pathWithFileName);
                t.ImagePath = pathWithFileName;
            }
            using (var context = new StudentContext())
            {
                context.Tutors.Add(t);
                // or
                // context.Add<Student>(std);

                context.SaveChanges();
            }
            return true;
        }

        public bool UpdateTutor(Tutor t, List<IFormFile> postedFiles)
        {

            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "TutorImages");
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
                Console.WriteLine(t.ImagePath);
                pathWithFileName = "TutorImages/" + file.FileName;
                t.ImagePath = pathWithFileName;
            }
            using (var context = new StudentContext())
            {

                // Use of lambda expression to access
                // particular record from a database
                var data = context.Tutors.FirstOrDefault(x => x.Email == t.Email);

                // Checking if any such record exist
                if (data != null)
                {
                    data.FirstName = t.FirstName;
                    data.LastName = t.LastName;
                    data.Password = t.Password;
                    data.Address = t.Address;
                    data.PhoneCode = t.PhoneCode;
                    data.PhoneNumber = t.PhoneNumber;
                    data.Country = t.Country;
                    data.Mode = t.Mode;
                    data.Subject1 = t.Subject1;
                    data.Subject2 = t.Subject2;
                    data.Fee1 = t.Fee1;
                    data.Fee2 = t.Fee2;
                    data.Availability = t.Availability;
                    data.QualificationSpec = t.QualificationSpec;
                    data.City = t.City;
                    data.Gender = t.Gender;
                    data.Qualification = t.Qualification;
                    data.ImagePath = t.ImagePath;
                    var res = context.SaveChanges();
                    if (res > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;

            }
        }
    }
}