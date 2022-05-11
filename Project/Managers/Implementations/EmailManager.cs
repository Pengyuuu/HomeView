using System;
using System.Text;
using Services.Contracts;
using System.Net.Mail;
using Services.Implementations;
using Managers.Contracts;
using System.Web;
using System.Net.Mime;
using System.Configuration;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    public class EmailManager : IEmailManager
    {
        private readonly IEmailService _emailService;
        private readonly string _fromEmail;

        public EmailManager()
        {
            _emailService = new EmailService();
            _fromEmail = ConfigurationManager.AppSettings.Get(2).ToString();

        }

        /* 
         *  Sends a confirmation email to a newly registered user.
         *  The email contains a URL link that the user can click on to confirm their account
         */
        public async Task<bool> AsyncSendConfirmationEmail(string registerEmail, string userOtp)
        {

            //for creating email confirmation token
            var token = HttpUtility.UrlEncode(userOtp);
            //creating link of API and attaching token and email    account/confirmEmailLink/{userOtp}/{email}
            string confirmationUrl = "http://54.219.16.154/api/login/account/confirmEmailLink/" + token + "/" + registerEmail;
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

            return await _emailService.AsyncSendEmail(message);
        }

        /* 
         *  Sends an account recovery email to a user that requested account recovery.
         *  The email contains a URL link that the user can click on to recover their account and change their password
         */
        public async Task<bool> AsyncSendRecoveryEmail(string recoverEmail, string recoverOtp)
        {

            //for creating recovery token
            var token = HttpUtility.UrlEncode(recoverOtp);
            //creating link of API and attaching token and email
            string recoveryURL = "http://54.219.16.154/api/account/recovery" + token + "/" + recoverEmail;
            StringBuilder stringAppend = new StringBuilder();


            MailMessage message = new MailMessage(_fromEmail, recoverEmail);
            message.IsBodyHtml = true;
            string homeviewRecoverMessage = "Hello! You requested to recover your account. Click the link below to continue with your recovery process. \nIf this was not you, please ignore this message. \n";
            string messageLink = "<a href=\"" + recoveryURL + "\"></a>";
            messageLink += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + recoveryURL);


            stringAppend.AppendLine(homeviewRecoverMessage);
            stringAppend.AppendLine(recoveryURL);
            message.Body = stringAppend.ToString();

            // non-ASCII characters in body and subject
            message.Body += Environment.NewLine;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "HomeView Account Recovery Email";
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(homeviewRecoverMessage, null, MediaTypeNames.Text.Plain));
            message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(messageLink, null, MediaTypeNames.Text.Html));

            return await _emailService.AsyncSendEmail(message);

        }
    }
}
