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
        public void AuthManager_ShouldGenerateJWTToken()
        {
            string testEmail = "bob@gmail.com";
            var actual = _authManager.GenerateJWTToken(testEmail);

            Assert.True(actual.Any());

        }

        [Fact]
        public void AuthManager_ShouldValidateUser()
        {
            string testEmail = "may@yahoo.com";
            var actual = _authManager.AuthenticateLogInUser(testEmail, "Password1234!");

            Assert.NotNull(actual);

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
            bool expected = true;

            bool actual = _authManager.AuthenticateRegisteredUser("csulbtestingtestingtesting@gmail.com", "TestPassword!12344556755");


            Assert.Equal(expected, actual);
        }


        [Fact]
        public void AuthManager_ShouldGenerateSalt()
        {
            var actual = _authManager.GetSalt();

            Assert.True(actual.Any());
        }

        [Fact]
        public void AuthManager_ShouldHashPassword()
        {
            string salt = _authManager.GetSalt();          
            string actual = _authManager.HashPassword("noAlphanumeric!!123345531", salt);

            Assert.True(actual.Any());
        }

        [Fact]
        public void HashPasswordTemp()
        {
            string expected = "test";
            string actual = _authManager.HashPassword("Password1234!", "PkvaMaj5QjIstpwWKT496HGHYPNouaTpkTZ42GBacEI=");

            Assert.Equal(expected, actual);

        }
    }
}
