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
        public bool ValidateLogIn(string email, string pw)
        {
            return _authenticationManager.AuthenticateLogInUser(email, pw);           
        }


        // when user clicks registration link from email -> authenticates user
        [Route("/account/confirmEmailLink/{userOtp}/{email}")]
        [HttpPost]
        public bool ConfirmRegisteredUser(string userOtp, string email)
        {
            // authenticates user from email, if true -> validates user into user db, returns false if invalid
            return _authenticationManager.AuthenticateRegisteredUser(email, userOtp);
            
        
        }

        // this is after confirming user/authenticaated user
        [Route("/login/{email}")]
        [HttpGet]
        public User GetUser(string email)
        {
            // directs user to homepage and auto activates user's profile in user db and deletes from reg db
            var fetchedUser = _userManager.GetUser(email);
            return fetchedUser;


        }




    }
}
