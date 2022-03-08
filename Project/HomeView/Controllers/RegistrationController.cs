using Microsoft.AspNetCore.Mvc;
using HomeView.Models;
using Core.User;
using System.Net.Mail;
using System.Net;
using System;

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
                    // create user and attach token
                    User u = new User(
                        null,
                        null,
                        regModel._userEmail,
                        regModel._userPass,
                        regModel._userDob,
                        null);
                    u.Token = Guid.NewGuid().ToString();
                    _userManager.CreateUser(u);
                    if (!SendConfirmationEmail(u))
                    {
                        return View("EmailSent");
                    }
                    else
                    {
                        return View("Index");
                    }
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

        public bool SendConfirmationEmail(User u)
        {
            try
            {
                var senderEmail = new MailAddress("homeviewcsulb@gmail.com", "Homeview");
                var receiverEmail = new MailAddress(u.Email, "Receiver");
                var password = "homeviewRocks";
                var sub = "Verify your homeview email!";
                var body = "/Registration/ConfirmEmail/" + u.Email + u.Token;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public ActionResult ConfrimEmail(string args)
        {
            try
            {

                return View();
            }
            catch
            {
                return View("Index");
            }
        }

    }
}
