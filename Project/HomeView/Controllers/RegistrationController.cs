using Microsoft.AspNetCore.Mvc;
using HomeView.Models;
using Core.User;
using System.Net.Mail;
using System.Net;

namespace HomeView.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserManager _userManager;

        public RegistrationController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp(RegistrationModel regModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    _userManager.CreateUser(new User(
                        regModel._firstName, 
                        regModel._lastName,
                        regModel._userEmail,
                        regModel._userPass,
                        regModel._userDob,
                        regModel._dispName));
                    return View("EmailSent");
                }        
                else
                {
                    return View("Index");
                }
            }
            catch
            {
                return View("Index");
            }
        }

        

    }
}
