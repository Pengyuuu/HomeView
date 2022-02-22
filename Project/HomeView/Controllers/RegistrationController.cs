using Microsoft.AspNetCore.Mvc;
using HomeView.Models;
using Core.User;
using System.Net.Mail;
using System.Net;

namespace HomeView.Controllers
{
    public class RegistrationController : Controller
    {
        private UserManager UserManager;

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp(RegistrationModel regModel)
        {
            try
            {
                UserManager = new UserManager();
                if (ModelState.IsValid)
                {
                    
                    UserManager.CreateUser(new User(
                        regModel._firstName, 
                        regModel._lastName,
                        regModel._userEmail,
                        regModel._userPass,
                        regModel._userDob,
                        regModel._dispName,
                        1, Role.User));
                    return View("EmailSent");
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
