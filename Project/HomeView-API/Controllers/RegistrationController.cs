using Managers.Contracts;
using Microsoft.AspNetCore.Mvc;
using Managers.Implementations;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeView_API.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationManager _registrationManager;


        public RegistrationController()
        {
            _registrationManager = new RegistrationManager();
           
        }


        // POST /registration/email/dob/pw
        [Route("validate/{email}/{dob}/{pw}")]
        [HttpGet]
        public bool ValidateUserFields(string email, string dob, string pw)
        {
            return _registrationManager.ValidateFields(email, dob, pw);        
        }


        // POST /registration/email/dob/pw
        [Route("/register/{email}/{dob}/{pw}")]
        [HttpPost]
        public string CreateNewUser(string email, string dob, string pw)
        {
            
            bool isValid = _registrationManager.ValidateFields(email, dob, pw);
            if (isValid)
            {
                bool isCreated = _registrationManager.CreateUser(email, dob, pw);
                if (isCreated)
                {
                    return "pass";
                }
                return "already created";

            }
            else
            {
                return "not valid";
            }
        }
    
    }
}
