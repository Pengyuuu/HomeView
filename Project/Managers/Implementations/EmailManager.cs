using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Contracts;
using System.Net.Mail;
using Services.Implementations;
using Managers.Contracts;

namespace Managers.Implementations
{
    public class EmailManager : IEmailManager
    {
        private readonly IEmailService _emailService;
        private string _message;
        private readonly string _fromEmail;

        public EmailManager()
        {
            _emailService = new EmailService();
            _fromEmail = "homeviewcsulb@gmail.com";
        }


        public bool SendConfirmationEmail(string registerEmail)
        {
            MailMessage message = new MailMessage(_fromEmail, registerEmail);
            message.Body = "Hello! Thanks for  registering for HomeView. Please click the URL/enter the token below to confirm your account";


            // Include some non-ASCII characters in body and subject.
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message.Body += Environment.NewLine + someArrows;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "HomeView Confirmation Email" + someArrows;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            // Set the method that is called back when the send operation ends.
            try
            {
                _emailService.AsyncSendEmail(message);
                return true;
            }
            catch
            {

            }
            return false;

        }

        public 



    }
}
