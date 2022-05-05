using Xunit;
using Managers.Contracts;
using Managers.Implementations;

namespace RegistrationTests
{
    public class RegistrationTests
    {
        private readonly IRegistrationManager _registrationManager = new RegistrationManager();

        [Fact]
        public void Register_ShouldRegisterUserSuccess()
        {
            bool expected = true;

            bool actual = _registrationManager.AsyncCreateUser("may@gmail.com","2000-12-09", "TestPassword!1234").Result;

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Register_ShouldRegisterUserUnsuccess()
        {
            bool expected = false;

            bool actual = _registrationManager.AsyncCreateUser("may@gmail.com", "2000-12-09", "Test!1234").Result;


            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Register_RegisterUserInvalidFields()
        {

            bool expected = true;
            bool actual = false;

            // Nothing
            bool testReg1 = _registrationManager.ValidateFields("",null,"");

            // pw Not long enough (11)
            bool testReg2 = _registrationManager.ValidateFields("A@gmail.com", "2000-09-09" ,"Not!ongenuf");

            // No Capital
            bool testReg3 = _registrationManager.ValidateFields("A@gmail.com", "2000-09-09", "nocapitalhere!");

            // No non-alpha
            bool testReg4 = _registrationManager.ValidateFields("A@gmail.com", "2000-09-09", "noAlphanumeric");
            // not old enough
            bool testReg5 = _registrationManager.ValidateFields("A@gmail.com", "2011-09-09", "noAlphanumeric");
            // not an email
            bool testReg6 = _registrationManager.ValidateFields("A@.om", "2000-09-09", "noAlphanumeric");


            if (!testReg1 && !testReg2 && !testReg3 && !testReg4 && !testReg5 && !testReg6)
            {
                actual = true;
            }
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Register_RegisterUserValidFields()
        {
            bool expected = true;
            bool actual = _registrationManager.ValidateFields("A@gmail.com", "2000-09-09", "noAlphanumeric!!123345531");

            Assert.Equal(expected, actual);
        }
        
    }

}
