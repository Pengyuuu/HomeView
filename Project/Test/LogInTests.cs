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
            string expected = "9XEOEJjXnDO/udjYShl0SM25lZw7qkJsTSt46INvp3I=";
            string actual = _authenticationManager.AuthenticateLogInUser("may@yahoo.com", "Password1234!");

            Assert.Equal(expected, actual);

        }

    }
}
