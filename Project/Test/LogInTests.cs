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
        private IAuthenticationManager _authenticationManager = new AuthenticationManager();

        
        [Fact]
        public void LogIn_ShouldLogInUserSuccess()
        {

            string actual = _authenticationManager.AuthenticateLogInUser("may@yahoo.com", "Password!1234");

            Assert.NotNull(actual);

        }
    }
}
