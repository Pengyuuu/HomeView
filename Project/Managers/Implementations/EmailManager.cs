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
using System.Net.Mime;

namespace Managers.Implementations
{
    public class EmailManager : IEmailManager
    {
        private readonly IEmailService _emailService;
        public string _fromEmail { get; set; }

        public EmailManager()
        {
            _emailService = new EmailService();
            
        }


        public bool SendConfirmationEmail(string registerEmail, string userOtp)
        {

            //for creating email confirmation token
            var token = HttpUtility.UrlEncode(userOtp);
            //creating link of API and attaching token and email
            string confirmationUrl = "https://homeview/account/confirmEmailLink/" + token + "/" + registerEmail;
            StringBuilder stringAppend = new StringBuilder();


            MailMessage message = new MailMessage(_fromEmail, registerEmail);
            message.IsBodyHtml = true;
            string homeviewConfirmMessage = "Hello! Thanks for  registering for HomeView. Please click the URL below to confirm your account. \n";
            string messageLink = "<a href=\"" + confirmationUrl + "\"></a>";
            messageLink += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + confirmationUrl);


            stringAppend.AppendLine(homeviewConfirmMessage);
            stringAppend.AppendLine(confirmationUrl);
            message.Body = stringAppend.ToString();

            // non-ASCII characters in body and subject
            message.Body += Environment.NewLine;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "HomeView Confirmation Email";
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(homeviewConfirmMessage, null, MediaTypeNames.Text.Plain));
            message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(messageLink, null, MediaTypeNames.Text.Html));


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
