using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System;
using Xunit;
using Managers.Contracts;
using Managers.Implementations;
using System.Net;

namespace EmailTests
{
    public class EmailTests
    {
        private string email = "@gmail.com";
        
        private IEmailManager _emailManager = new EmailManager();

        
        [Fact]
        public bool SendEmail1()
        {
            IAuthenticationManager auth = new Managers.Implementations.AuthenticationManager();
            string otp = auth.GenerateOTP();
            return _emailManager.SendConfirmationEmail(email, otp);
            
            
        }


    }

}
