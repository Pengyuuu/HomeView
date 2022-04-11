using Managers.Contracts;
using System.Web.Http;

namespace HomeView_API.Controllers
{
    [Route("/login")]
    public class LoginController : ApiController
    {
        private readonly IUserManager _userManager;

        private readonly HttpClient _httpClient;

        public LoginController(IUserManager userManager, HttpConfiguration config)
        {
            _userManager = userManager;
            _httpClient = new HttpClient();
            config.MapHttpAttributeRoutes();
        }


    }
}
