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
        public void Register_ShouldRegisterUserSuccess()
        {
            bool expected = true;

            bool actual = _authManager.GenerateOTP("ctest@gmail.com", "2000-12-09", "TestPassword!12344556755");

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Register_ShouldRegisterUserUnsuccess()
        {
            bool expected = false;

            bool actual = _authManager.GenerateJWTToken("csulbtestingtestingtesting@gmail.com", "2000-12-09", "TestPassword!12344556755");


            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Register_RegisterUserValidFields()
        {
            bool expected = true;
            bool actual = _authManager.AuthenticateRegisteredUser("A@gmail.com", "2000-09-09", "noAlphanumeric!!123345531");

            Assert.Equal(expected, actual);
        }
    }
}
