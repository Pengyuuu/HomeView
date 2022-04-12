//using Microsoft.AspNetCore.Mvc;
using Managers.Contracts;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeView_API.Controllers
{
    [Route("/registration")]
    public class RegistrationController : ApiController
    {
        private readonly IRegistrationManager _registrationManager;
        private readonly HttpClient _httpClient;


        public RegistrationController(IRegistrationManager registrationManager, HttpConfiguration config)
        {
            _registrationManager = registrationManager;
            _httpClient = new HttpClient();
            // maps web api routes
            config.MapHttpAttributeRoutes();
        }


        // GET /registration/email/dob/pw
        [Route("/registration/{email}/{dob}/{pw}")]
        [HttpPost]
        public IHttpActionResult CreateNewUser(string email, string dob, string pw)
        {
            
            bool isValid = _registrationManager.ValidateFields(email, dob, pw);
            if (isValid)
            {
                bool isCreated = _registrationManager.CreateUser(email, dob, pw);
                if (isCreated)
                {
                    return Ok("Check Email for confirmation.");
                }
                return BadRequest("User already exists.");

            }
            else
            {
                return BadRequest("Invalid fields");
            }
        }

        // POST /registration/OTP
        [Route("/registration/{otp}")]
        [HttpPost]
        public void ConfirmNewUser(string otp)
        {

        }

        // PUT api/<RegistrationController>/5
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegistrationController>/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
