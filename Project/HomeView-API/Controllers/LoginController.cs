using Core.User;
using Managers.Contracts;
using Microsoft.AspNetCore.Mvc;
using Managers.Implementations;

namespace HomeView_API.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IAuthenticationManager _authenticationManager;

        public LoginController()
        {
            _userManager = new UserManager();
            _authenticationManager = new AuthenticationManager();
        }

        [Route("validate/{email}/{pw}")]
        [HttpGet]
        public ActionResult<bool> ValidateLogIn(string email, string pw)
        {
            return _authenticationManager.AuthenticateLogInUser(email, pw);           
        }


        // when user clicks registration link from email -> authenticates user
        [Route("account/confirmEmailLink/{userOtp}/{email}")]
        //[AllowAnonymous]
        [HttpGet]
        public ActionResult<string> ConfirmRegisteredUser(string userOtp, string email)
        {
            if (userOtp == null || email == null)
            {
                return "Error";
            }

            // newly registered user confirms email from confirmation link, if true -> validates user into user db, returns false if invalid (expired otp)
            bool result = _authenticationManager.AuthenticateRegisteredUser(email, userOtp);
            if (result)
            {
                return "Email confirmed.";
            }
            return Ok("Invalid confirmation.");
            
        
        }

        // this is after confirming user/authenticaated user
        [Route("get/{email}")]
        [HttpGet]
        public ActionResult<User> GetUser(string email)
        {
            // directs user to homepage and auto activates user's profile in user db and deletes from reg db
            var fetchedUser = _userManager.GetUser(email);
            return fetchedUser;


        }

        // generates JWT token for a valid user
        [Route("get/token/{email}")]
        [HttpGet]
        public ActionResult<string> GetJWTToken(string email)
        {
            // directs user to homepage and auto activates user's profile in user db and deletes from reg db
            var token = _authenticationManager.GenerateJWTToken(email);
            return token;


        }




    }
}
