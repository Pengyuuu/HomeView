using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers.Contracts;
using Managers.Implementations;
using Xunit;

namespace AuthTesting
{
    public class AuthTests
    {
        private readonly IAuthenticationManager _authManager = new AuthenticationManager();

        [Fact]
        public void AuthManager_ShouldGenereateJWTToken()
        {
            string testEmail = "bob@gmail.com";
            var actual = _authManager.GenerateJWTToken(testEmail);

            Assert.True(actual.Any());

        }

        [Fact]
        public void AuthManager_ShouldGenerateOTP()
        {
            var actual = _authManager.GenerateOTP();

            Assert.True(actual.Any());
        }

        [Fact]
        public void AuthManager_ShouldAuthenticateRegisteredUser()
        {
            bool expected = false;

            bool actual = _authManager.GenerateJWTToken("csulbtestingtestingtesting@gmail.com", "2000-12-09", "TestPassword!12344556755");


            Assert.Equal(expected, actual);
        }


        [Fact]
        public void AuthManager_ShouldAuthenticateLogInUser()
        {
            bool expected = true;
            bool actual = _authManager.AuthenticateRegisteredUser("A@gmail.com", "2000-09-09", "noAlphanumeric!!123345531");

            Assert.Equal(expected, actual);
        }
      
    }
}
