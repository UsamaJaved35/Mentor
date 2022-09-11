using Mentor.Models;
using Mentor.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mentor.Models;

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
        public async Task<IActionResult> LoginTutor(Login model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Password) ||
                   string.IsNullOrEmpty(model.Email))
                {
                    return View("LoginTutor");
                }

                Tutor tutor = login.TutorLogin(model.Email, model.Password);
                if (tutor != null)
                {
                    HttpContext.Session.SetString("T_Id", tutor.TId.ToString());
                    return RedirectToAction("TutorProfile", "Tutor", tutor);
                }
                else
                    return RedirectToAction("Error", "Tutor");
            }
            return View();
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
                    HttpContext.Session.SetString("S_Id", s.SId.ToString());
                    Console.WriteLine(HttpContext.Session.GetString("S_Id"));
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
        [HttpGet]
        public IActionResult LogoutAsTutor()
        {
            return View("LoginTutor");  
        }
        [HttpGet]
        public IActionResult LogoutAsStudent()
        {
            return View("LoginStudent");
        }
    }
}