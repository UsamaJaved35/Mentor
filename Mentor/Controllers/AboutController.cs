using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutor_Finder.Controllers
{
    public class AboutController : Controller
    {
        public ViewResult About()
        {
            return View();
        }
    }
}
