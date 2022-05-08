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

        // Probably don't need this since we test in FrontEnd and CreateNewUser Manager
        // POST /registration/email/dob/pw
        [Route("validate/{email}/{dob}/{pw}")]
        [HttpGet]
        public ActionResult<bool> ValidateUserFields(string email, string dob, string pw)
        {
            return _registrationManager.ValidateFields(email, dob, pw);        
        }


        // POST /registration
        [HttpPost]
        public ActionResult<string> CreateNewUser([FromQuery] string email, [FromQuery] string dob, [FromQuery] string pw)
        {
            
            bool isValid = _registrationManager.ValidateFields(email, dob, pw);
            if (isValid)
            {
                bool isCreated = _registrationManager.AsyncCreateUser(email, dob, pw).Result;
                if (isCreated)
                {
                    return Ok("pass");
                }
                return BadRequest("already created");

            }
            else
            {
                return BadRequest("not valid");
            }
        }
    
    }
}
