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
            IHttpActionResult httpActionResult = new 
            
            bool isValid = _registrationManager.ValidateFields(email, dob, pw);
            if (isValid)
            {
                _registrationManager.CreateUser(email, dob, pw);
                response.StatusCode = 200;

            }
            else
            {
                response.StatusCode = 400;
            }
            return response;
        }

        // POST /registration
        [HttpPost]
        public void Post([FromBody] string value)
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
