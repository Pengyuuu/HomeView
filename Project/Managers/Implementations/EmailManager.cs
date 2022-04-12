using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Contracts;
using System.Net.Mail;
using Services.Implementations;
using Managers.Contracts;
using System.Web;


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


        public bool SendConfirmationEmail(string registerEmail, string userOtp)
        {

            //for creating email confirmation token
            var token = HttpUtility.UrlEncode(userOtp);
            //creating a proper link of my API and attaching token and email
            string confirmationUrl = "https://homeview/account/confirmEmailLink?token=" + token + "&email=" + registerEmail;
            StringBuilder stringAppend = new StringBuilder();


            MailMessage message = new MailMessage(_fromEmail, registerEmail);
            message.IsBodyHtml = true;
            string homeviewConfirmMessage = "Hello! Thanks for  registering for HomeView. Please click the URL below to confirm your account. \n";
            string messageLink = "<a href=\"" + confirmationUrl + "\"></a>";
            

            stringAppend.AppendLine(homeviewConfirmMessage);
            stringAppend.AppendLine(messageLink);
            message.Body = stringAppend.ToString();

            // non-ASCII characters in body and subject
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message.Body += Environment.NewLine + someArrows;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "HomeView Confirmation Email" + someArrows;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
          
         
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

        



    }
}
