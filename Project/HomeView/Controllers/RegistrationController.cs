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
        private UserManager UserManager;
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
        public ActionResult SignUp(RegistrationModel regModel)
        {
            try
            {
                UserManager = new UserManager();
                if (ModelState.IsValid)
                {
                    
                    UserManager.CreateUser(new Core.User.User(
                        regModel._firstName, 
                        regModel._lastName,
                        regModel._userEmail,
                        regModel._userPass,
                        regModel._userDob,
                        regModel._dispName,
                        1, Role.User));
                    return View();
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
