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

        // Upon successful login, user is generated a jwt Token
        // GET api/<LoginController>
        [HttpGet]
        public ActionResult<string> ValidateLogIn([FromQuery]string email, [FromQuery] string pw)
        {
            var valid = _authenticationManager.AuthenticateLogInUser(email, pw); 
            if (valid is not null)
            {
                return Ok(valid);
            }
            return BadRequest("Invalid");
        }


        // when user clicks registration link from email -> authenticates user
        [Route("account/confirmEmailLink/{userOtp}/{email}")]
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
                return Ok("Email confirmed. Go to myhomeview.me to log in. Happy watching!");
            }
            return BadRequest("Invalid confirmation.");
        }

        // this is after confirming user/authenticaated user
        [Route("get/{email}")]
        [HttpGet]
        public async Task<ActionResult<User>> AsyncGetUser(string email)
        {
            // directs user to homepage and auto activates user's profile in user db and deletes from reg db
            var fetchedUser = await _userManager.AsyncGetUser(email);
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
