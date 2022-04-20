using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Managers.Contracts;
using Managers.Implementations;

namespace LogInTests
{
    public class LogInTests
    {
        private readonly IAuthenticationManager _authenticationManager = new AuthenticationManager();

        [Fact]
        public void LogIn_ShouldLogInUserSuccess()
        {
            bool expected = true;

            bool actual = _authenticationManager.AuthenticateLogInUser("testing@gmail.com", "TestPassword!12344556755");

            Assert.Equal(expected, actual);

        }
    }
}
