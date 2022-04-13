using Managers.Contracts;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeView_API.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationManager _registrationManager;


        public RegistrationController(IRegistrationManager registrationManager)
        {
            _registrationManager = registrationManager;
           
        }


        // GET /registration/email/dob/pw
        [Route("/registration/{email}/{dob}/{pw}")]
        [HttpPost]
        public bool CreateNewUser(string email, string dob, string pw)
        {
            
            bool isValid = _registrationManager.ValidateFields(email, dob, pw);
            if (isValid)
            {
                bool isCreated = _registrationManager.CreateUser(email, dob, pw);
                if (isCreated)
                {
                    return true;
                }
                return false;

            }
            else
            {
                return false;
            }
        }
    
    }
}
