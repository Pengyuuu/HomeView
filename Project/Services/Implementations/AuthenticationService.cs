using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Contracts;
using Services.Implementations;

namespace Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;

        public AuthenticationService()
        {
            _userService = new UserService();
        }

        // used for when newly registered users try to log in
        public async Task<string> AsyncGenerateOTP()
        {
            string p = "sdljfsdklsfjslkjf";
            return p;
        }

        public bool AuthenticateRegisteredUser(string email, string userOtp)
        {
            var fetchedUser = _userService.GetRegisteredUser(email);
            if (fetchedUser != null) 
            {
              var expireTime = (fetchedUser.RegDate).AddMinutes(2);     // otp expires after 2 minutes
              if ((DateTime.UtcNow < expireTime) && (fetchedUser.Token == userOtp))
                {
                    // deletes user from registration db
                    _userService.DeleteUser(email, 0);
                    // creates user into user db
                    _userService.CreateUser(fetchedUser, 1);
                    return true;
                }
            }
            return false;
        }

        public bool AuthenticateLogInUser(string email, string pw)
        {
            var fetchedUser = _userService.GetUser(email);
            if ((fetchedUser != null) && (fetchedUser.Password == pw))
            {                               
                return true;               
            }
            return false;
        }

    }
}
