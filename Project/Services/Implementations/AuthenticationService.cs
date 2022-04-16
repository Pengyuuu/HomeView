using System;
using System.Security.Cryptography;
using System.Text;
using Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;

        public AuthenticationService()
        {
            _userService = new UserService();
        }

        // generates jwt token, should this be async?
        public string GenerateJWTToken(string email)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                // sample security key but replace with one from config???
                var encoded = Base64UrlEncoder.Encode("securitykeyexample");
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(encoded));
                var claims = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", email) }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    Issuer = "HomeView",
                    Audience = "HomeViewUser",
                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                };
                SecurityToken token = tokenHandler.CreateToken(claims);
                return tokenHandler.WriteToken(token);
            }

            catch
            {
                return null;
            }
        }

        // creates randomized string of randomized length with min of 8 char
        public string GenerateOTP()
        {
            string alphaNum = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz";
            string otp = "";

            Random rand = new Random();
            const int MIN_LENGTH = 8;
            const int MAX_LENGTH = 41;
            int otpLength = (rand.Next(MIN_LENGTH, MAX_LENGTH));

            // otp of varying length with minimum of 8
            for (int i = 0; i < otpLength; i++)
            {
                // gets random index for alpha string
                int randIndex = rand.Next(alphaNum.Length);
                otp += alphaNum[randIndex];         
            }

            return otp;
        }

        public bool AuthenticateRegisteredUser(string email, string userOtp)
        {
            var fetchedUser = _userService.GetRegisteredUser(email);
            // user is found and they're unconfirmed
            if (fetchedUser != null && (!fetchedUser.Status))
            {
                var expireTime = (fetchedUser.RegDate).AddMinutes(2);     // otp expires after 2 minutes
                if ((DateTime.UtcNow < expireTime) && (fetchedUser.Token == userOtp))
                {
                    // creates user into user db
                    // status is set to true for being a first time user
                    fetchedUser.Status = true;
                    // resets token so it is no longer valid now that user is confirmed already
                    fetchedUser.Token = "";
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
