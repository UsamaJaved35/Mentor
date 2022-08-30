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
        public JsonResult StudentForm(Student model)
        {
            if (model == null)
            {
                return Json(new { status = 0, message = "FAILED TO ADD STUDENT !!!!" });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if(studentRepo.AddStudent(model))
                    {
                        return Json(new { status = 1, message = "STUDENT ADDED SUCCESSFULLY!!!" });
                    }
                    else
                        return Json(new { status = 0, message = "FAILED TO ADD STUDENT !!!!" });
                }
                else
                    return Json(new { status = 0, message = "FAILED TO ADD STUDENT !!!!" });
            }
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
