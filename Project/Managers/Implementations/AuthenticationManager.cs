using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Contracts;
using Services.Implementations;
using Managers.Contracts;

namespace Managers.Implementations
{
    // mechanism for identifying a valid user of the system (validation for logging in a user)
    // scope: any user attempting to use the system
    public class AuthenticationManager : IAuthenticationManager
    {
        private UserManager _userManager;
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationManager()
        {
            _userManager = new UserManager();
            _authenticationService = new AuthenticationService();
        }

        // for registering users
        public string generateOTP()
        {
            return _authenticationService.AsyncGenerateOTP().Result;
        }


    }
}
