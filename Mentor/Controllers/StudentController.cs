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
        [HttpPost]
        public JsonResult sendRequest(string data)
        {
            string id=HttpContext.Session.GetString("S_Id");
            if (id != null)
            {
                if (studentRepo.sendRequest(data, int.Parse(id)))
                    return Json("REQUEST SENT!!");
            }
            return Json("ERROR !!");
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
        [HttpGet]
        public ViewResult StudentProfileUpdate(Student student)
        {
            return View(student);
        }
        [HttpPost]
        public IActionResult StudentProfileUpdate(Student model, List<IFormFile> postedFiles)
        {
            if (model == null)
            {
                return View("StudentProfileUpdate");
                //return Json(new { status = 0, message = "FAILED TO UPDATE STUDENT !!!!" });
            }
            else
            {
                
                if (ModelState.IsValid)
                {
                    //string tempStudent = studentRepo.imageExists(model.Email);
                    //model.ImagePath = tempStudent;
                    if (studentRepo.UpdateStudent(model, postedFiles))
                    {
                        return RedirectToAction("StudentProfile", "student", model);
                        //return Json(new { status = 1, message = "PROFILE UPDATED SUCCESSFULLY!!!" ,s=model});
                    }
                    else
                        return View("StudentProfileUpdate");
                    //return Json(new { status = 0, message = "FAILED TO UPDATE !!!!" });
                }
                else
                    return View("StudentProfileUpdate");
                //return Json(new { status = 0, message = "FAILED TO UPDATE !!!!" });
            }
        }
    }
}