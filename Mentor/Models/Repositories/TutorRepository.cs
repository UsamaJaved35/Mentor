using Mentor.Models.Interfaces;
using Tutor_Finder.Models;
using System.Diagnostics;
namespace Mentor.Models.Repositories
{
    public class TutorRepository:ITutor
    {
        private readonly IWebHostEnvironment Environment;
        public TutorRepository(IWebHostEnvironment environment)
        {
            Environment = environment;
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
    }
}