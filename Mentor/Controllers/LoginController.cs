using Mentor.Models;
using Mentor.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutor_Finder.Models;

namespace Tutor_Finder.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin login;

        public LoginController(ILogin l)
        {
            login = l;
        }
        [HttpGet]
        public ViewResult LoginTutor()
        {
            return View("LoginTutor");
        }
        [HttpPost]
        public ViewResult LoginTutor(Tutor t)
        {
            TutorRepository tr = new TutorRepository();
            if (tr.Login(t))
                return View("Tutor","TutorProfile");
            else
                return View("Error");
        }
        [HttpGet]
        public ViewResult LoginStudent()
        {
            return View("LoginStudent");
        }
        [HttpPost]
        public async Task<IActionResult> LoginStudent(Login model)
        {
            if (ModelState.IsValid)
            {
                if(string.IsNullOrEmpty(model.Password)||
                   string.IsNullOrEmpty(model.Email))
                {
                    return View("Error");
                }

                Student s = login.StudentLogin(model.Email, model.Password);
                if(s!=null)
                {
                    Console.WriteLine(s.Address);
                    //ViewBag["Std"] = s;
                    return RedirectToAction("StudentProfile", "Student",s);
                }
                else
                    return RedirectToAction("Error","Student");
            }
            return View(model);
        }
       // [HttpGet]
        //public async Task<IActionResult> Logout()
        //{
        //    await signInManager.SignOutAsync();
        //    return RedirectToAction("index", "home");
        //}
    }
}