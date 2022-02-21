using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeView.Models;
using Core.User;
using HomeView.Controllers;

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
                    int month = 0;
                    int day = 0;
                    int yr = 0;
                    ViewData["firstN"] = regModel._firstName;
                    ViewData["lastN"] = regModel._lastName;
                    ViewData["email"] = regModel._userEmail;
                    ViewData["pw"] = regModel._userPass;
                    ViewData["mo"] = month;
                    ViewData["day"] = day;
                    ViewData["yr"] = yr;
                    ViewData["disp"] = regModel._dispName;
                    regModel._userDob = new DateTime(yr, month, day);
                    UserManager UM = new UserManager();

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
