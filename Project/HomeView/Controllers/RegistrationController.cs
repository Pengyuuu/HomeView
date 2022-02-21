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

        [HttpPost]
        public IActionResult SignUp(RegistrationModel regModel)
        {
            try
            {
                string confPass = "";
                ViewData["email"] = regModel._userEmail;
                ViewData["pw"] = regModel._userPass;
                ViewData["confPass"] = confPass;
                ViewData["hasNewsletter"] = regModel._hasNewsletter;

                if (regModel._userPass == confPass)
                {


                    return View("");
                }
                else
                {
                    return View("");
                }               
            }
            catch
            {
                return View("");
            }
        }
     
    }
}
