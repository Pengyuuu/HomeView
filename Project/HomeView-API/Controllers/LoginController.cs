using Core.User;
using Managers.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HomeView_API.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IAuthenticationManager _authenticationManager;

        public LoginController(IUserManager userManager, IAuthenticationManager authenticationManager)
        {
            _userManager = userManager;
            _authenticationManager = authenticationManager;
        }

        [Route("/login/{email}/{pw}")]
        [HttpGet]
        public bool LogIn(string email, string pw)
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
        [Route("/login/{email}/{pw}/{token}")]
        [HttpGet]
        public User GetUser(string email)
        {
            // directs user to homepage and auto activates user's profile in user db and deletes from reg db
            return null;         


        }




    }
}
