using Mentor.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutor_Finder.Models;
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
                    return View("Error");
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
        public ViewResult TutorProfileUpdate()
        {
            return View();
        }
        //[HttpPost]
        //public ViewResult TutorProfileUpdate()
        //{
        //    return View();
        //}
    }
}