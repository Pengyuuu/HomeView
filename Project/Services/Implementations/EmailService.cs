using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Services.Contracts;

namespace Services.Implementations
{
    public class EmailService : IEmailService
    {
        private SmtpClient _smtpClient;
        private readonly string _server;
        private readonly int _port;
        public EmailService()
        {
            _server = "smtp.gmail.com";
            _port = 465;
            _smtpClient = new SmtpClient(_server, _port);
            _smtpClient.EnableSsl = true;
        }

        public async Task<bool> AsyncSendEmail(MailMessage message)
        {

            using (_smtpClient)
            {
                try
                {

                    //NetworkCredential NetworkCred = new NetworkCredential(model.Email, model.Password);
                    _smtpClient.UseDefaultCredentials = true;
                    //smtp.Credentials = NetworkCred;

                    await _smtpClient.SendMailAsync(message);

                    return true;
                }
                catch
                {

                }
            }
            return false;
        }

    }
}
