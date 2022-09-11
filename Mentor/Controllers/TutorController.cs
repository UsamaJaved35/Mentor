using Mentor.Models;
using Mentor.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Tutor_Finder.Controllers
{
    public class TutorController : Controller
    {
        private readonly ITutor tutorRepo;
        private readonly ILogger<TutorController> _logger;

        public TutorController(ILogger<TutorController> logger, ITutor t)
        {
            tutorRepo = t;
            _logger = logger;
        }
        [HttpGet]
        public ViewResult TutorForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult TutorForm(Tutor t, List<IFormFile> postedFiles)
        {
            if (ModelState.IsValid)
            {
                if (tutorRepo.AddTutor(t,postedFiles))
                {
                    return View("Welcome");
                }
                else
                    return View();
            }
            else
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
        [HttpGet]
        public ViewResult TutorProfile(Tutor t)
        {
            return View(t);
        }
        [HttpGet]
        public ViewResult TutorProfileUpdate(Tutor t)
        {
            return View(t);
        }
        [HttpPost]
        public IActionResult TutorProfileUpdate(Tutor model, List<IFormFile> postedFiles)
        {
            if (model == null)
            {
                return View("TutorProfileUpdate",model);
                //return Json(new { status = 0, message = "FAILED TO UPDATE STUDENT !!!!" });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    //string tempStudent = studentRepo.imageExists(model.Email);
                    //model.ImagePath = tempStudent;
                    if (tutorRepo.UpdateTutor(model, postedFiles))
                    {
                        return RedirectToAction("TutorProfile", "tutor", model);
                        //return Json(new { status = 1, message = "PROFILE UPDATED SUCCESSFULLY!!!" ,s=model});
                    }
                    else
                        return View("TutorProfileUpdate");
                    //return Json(new { status = 0, message = "FAILED TO UPDATE !!!!" });
                }
                else
                    return View("TutorProfileUpdate",model);
                //return Json(new { status = 0, message = "FAILED TO UPDATE !!!!" });
            }
        }
        [HttpGet]
        public IActionResult GetTutorsList()
        {
            var list = tutorRepo.GetAllTutors();
            return View(list);
        }
        [HttpGet]
        public IActionResult SeeRequests()
        {
            string id = HttpContext.Session.GetString("T_Id");
            var list = tutorRepo.SeeRequests(id);
            return View(list);
        }
        [HttpPost]
        public JsonResult requestStatus(bool status,int id)
        {
            if (tutorRepo.requestStatus(status,id))
            {
                if(status)
                return Json("REQUEST ACCEPTED !!");
                else
                    return Json("REQUEST DECLINED !!");
            }
            return Json("REQUEST DECLINED !!");
        }
        //[HttpPost]
        //public ViewResult TutorProfileUpdate()
        //{
        //    return View();
        //}
    }
}