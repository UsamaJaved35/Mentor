using Mentor.Models;
using Mentor.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Mentor.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent studentRepo;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController>logger,IStudent s)
        {
            studentRepo = s;
            _logger = logger;
        }
        [HttpGet]
        public ViewResult StudentForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentForm(Student model)
        {
            if (ModelState.IsValid)
            {
                if(studentRepo.AddStudent(model))
                {
                    return View("Welcome");
                }
                else
                    return View("Error");
            }
            return View();
    }
        public ViewResult Welcome()
        {
            return View();
        }
        public ViewResult Error()
        {
            return View();
        }
        //[Authorize]
        [HttpGet]
        public ViewResult StudentProfile(Student student)
        {
            return View(student);
        }
    }
}
