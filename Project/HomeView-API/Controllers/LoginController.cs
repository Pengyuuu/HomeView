using Managers.Contracts;
using System.Web.Http;

namespace HomeView_API.Controllers
{
    [Route("/login")]
    public class LoginController : ApiController
    {
        private readonly IUserManager _userManager;
        private readonly IAuthenticationManager _authenticationManager;

        private readonly HttpClient _httpClient;

        public LoginController(IUserManager userManager, HttpConfiguration config)
        {
            _userManager = userManager;
            _httpClient = new HttpClient();
            config.MapHttpAttributeRoutes();
        }

        [Route("/login/{email}/{pw}")]
        [HttpGet]
        public IHttpActionResult LogIn(string email, string pw)
        {

        }


        // when user clicks registration link from email -> auto confirm
        [Route("/account/confirmEmailLink/{userOtp}/{email}")]
        [HttpPost]
        public IHttpActionResult ConfirmUser(string userOtp, string email)
        {
            // user is confirmed, directs them to homepage and auto activates user's profile in user db and deletes from reg db
            _authenticationManager.generateOTP();    
        
        }


    }
}
