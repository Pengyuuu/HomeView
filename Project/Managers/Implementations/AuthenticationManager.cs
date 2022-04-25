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

        public string GenerateJWTToken(string email)
        {
            return _authenticationService.GenerateJWTToken(email);
        }

        // for registering users
        public string GenerateOTP()
        {
            return _authenticationService.GenerateOTP();
        }

        public bool AuthenticateRegisteredUser(string email, string userOtp)
        {
            return _authenticationService.AuthenticateRegisteredUser(email, userOtp);
        }

        public string AuthenticateLogInUser(string email, string pw)
        {
            return _authenticationService.AuthenticateLogInUser(email, pw);
        }

        public string HashPassword(string pw, string salt)
        {
            return _authenticationService.HashPassword(pw, salt);
        }

        public string GetSalt()
        {
            return _authenticationService.GenerateSalt();
        }


    }
}
