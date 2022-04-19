using System.Threading.Tasks;
using System.Net.Mail;
using Services.Contracts;
using System.Net;
using System.Configuration;
using System;

namespace Services.Implementations
{
    public class EmailService : IEmailService
    {
        private SmtpClient _smtpClient;
        private readonly string _server;
        private readonly int _port;
        public readonly string _fromEmail;
        public readonly string _key;
        public EmailService()
        {                    
            _smtpClient = new SmtpClient(_server, _port);
            _server = ConfigurationManager.AppSettings.Get(0).ToString();
            _port = Convert.ToInt32(ConfigurationManager.AppSettings.Get(1));
            _fromEmail = ConfigurationManager.AppSettings.Get(2).ToString();
            _key = ConfigurationManager.AppSettings.Get(3).ToString();

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
