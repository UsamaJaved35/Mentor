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
        [HttpGet]
        public ViewResult TutorForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult TutorForm(Tutor t)
        {
            TutorRepository tr = new TutorRepository();
            if (ModelState.IsValid)
            {
                tr.AddTutor(t);
                  return View("Welcome");
                //else
                //    return View("Error");
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
        public ViewResult TutorProfile()
        {
            return View();
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