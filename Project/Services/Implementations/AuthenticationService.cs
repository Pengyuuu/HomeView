using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                    // creates user into user db
                    // status is set to true for being a first time user
                    fetchedUser.Status = true;
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

        public string HashPassword(string pw)
        {
            SHA256 pww = SHA256.Create();

            string salt = GenerateSalt();

            // Converts the password string into bytes
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(pw + salt);

            // Computes hash of data using the SHA256 algorithm
            byte[] hash = pww.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        public string GenerateSalt()
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();

            var buffer = new byte[32];

            // Fills buffer array with a random sequence of 32 values
            rng.GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }
    }
}
