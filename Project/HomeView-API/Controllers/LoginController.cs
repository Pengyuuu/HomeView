using Core.User;
using Managers.Contracts;
using Microsoft.AspNetCore.Mvc;
using Managers.Implementations;

namespace HomeView_API.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult ValidateLogIn([FromQuery] string email, [FromQuery] string pw)
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

        [HttpGet("validate")]
        public IActionResult ValidateJWT()
        {
            bool headerTry = Request.Headers.TryGetValue("Authorization", out var token);
            if (headerTry)
            {
                if (_authenticationManager.ValidateToken(token))
                {
                    return Ok(token);
                }
                else
                {
                    return Unauthorized("Could not validate token");
                }
            }
            else
            {
                return BadRequest("No JWT token found");
            }
        }
    }
}
