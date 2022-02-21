using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Core.Registration;

namespace RegistrationTests
{
    public class RegistrationTests
    {
        [Fact]
        public void Register_isPasswordValidShouldReturnTrue()
        {
            bool expected = true;

            Register testRegister = new Register();

            bool actual = testRegister.IsPassWordValid("iLoveL3ague!");

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Register_isPasswordValidShouldReturnFalse()
        {
            bool expected = true;
            bool actual = false;

            Register testRegister = new Register();

            // Nothing
            bool testReg1 = testRegister.IsPassWordValid("");

            // Not long enough (11)
            bool testReg2 = testRegister.IsPassWordValid("Not!ongenuf");

            // No Capital
            bool testReg3 = testRegister.IsPassWordValid("nocapitalhere!");

            // No non-alpha
            bool testReg4 = testRegister.IsPassWordValid("noAlphanumeric");

            if (!testReg1 && !testReg2 && !testReg3 && !testReg4)
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Register_isEmailValidShouldReturnTrue()
        {
            bool expected = true;

            Register testRegister = new Register();

            bool actual = testRegister.IsEmailValid("totallyrea1email@gmail.com");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Register_isEmailValidShouldReturnFalse()
        {
            bool expected = true;
            bool actual = false;

            Register testRegister = new Register();

            // Only ".com"
            bool testReg1 = testRegister.IsEmailValid("notanemailhere1.com");

            // Only "@"
            bool testReg2 = testRegister.IsEmailValid("not@nemailhere2");

            if (!testReg1 && !testReg2)
            {
                actual = true;
            }


            Assert.Equal(expected, actual);
        }
    }
}
