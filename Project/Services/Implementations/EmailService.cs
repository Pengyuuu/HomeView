using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Services.Contracts;
using System.Net;
using System.Configuration;


namespace Services.Implementations
{
    public class EmailService : IEmailService
    {
        private SmtpClient _smtpClient;
        private readonly string _server;
        private readonly int _port;
        public string FromEmail { get; set; }
        public string Key { get; set; }
        public EmailService()
        {
            
            _server = "Smtp.Server";
            _port = 0;
            _smtpClient = new SmtpClient(_server, _port);
            _smtpClient.EnableSsl = true;
            _smtpClient.Host = _server;

        }

        public async Task<bool> AsyncSendEmail(MailMessage message)
        {

            using (_smtpClient)
            {
                try
                {

                    NetworkCredential NetworkCred = new NetworkCredential("", "");
                    _smtpClient.UseDefaultCredentials = false;
                    _smtpClient.Credentials = NetworkCred;
                    _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
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
