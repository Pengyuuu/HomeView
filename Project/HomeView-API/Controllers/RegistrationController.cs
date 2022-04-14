using Managers.Contracts;
using Microsoft.AspNetCore.Mvc;
using Managers.Implementations;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeView_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationManager _registrationManager;


        public RegistrationController()
        {
            _registrationManager = new RegistrationManager();
           
        }


        // POST /registration/email/dob/pw
        [Route("/validate/{email}/{dob}/{pw}")]
        [HttpGet]
        public JsonResult ValidateUserFields(string email, string dob, string pw)
        {
            bool isValid = _registrationManager.ValidateFields(email, dob, pw);        
            if (isValid)
            {
                return new JsonResult("Validated. Check email");
            }
            return new JsonResult("Invalid fields.");
        }


        // POST /registration/email/dob/pw
        //[Route("/register/{email}/{dob}/{pw}")]
        [HttpPost]
        public JsonResult CreateNewUser(string email, string dob, string pw)
        {
            
            bool isValid = _registrationManager.ValidateFields(email, dob, pw);
            if (isValid)
            {
                bool isCreated = _registrationManager.CreateUser(email, dob, pw);
                if (isCreated)
                {
                    return new JsonResult("pass");
                }
                return new JsonResult("already created");

            }
            else
            {
                return new JsonResult("not valid");
            }
        }
    
    }
}
