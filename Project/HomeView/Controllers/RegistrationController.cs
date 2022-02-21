using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeView.Models;

namespace HomeView.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        // Post: Home/User Sign Up
        [HttpPost]
        public IActionResult SignUp(RegistrationModel regModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewData["email"] = regModel._userEmail;
                    ViewData["pw"] = regModel._userPass;
                    ViewData["hasNewsletter"] = regModel._hasNewsletter;

                    return View("Index");
                }        
                else
                {
                    return View("InvalidInput");
                }
            }
            catch
            {
                return View("InvalidInput");
            }
        }
     
    }
}
