using System.Threading.Tasks;
using System.Net.Mail;
using Services.Contracts;
using System.Net;



namespace Services.Implementations
{
    public class EmailService : IEmailService
    {
        private SmtpClient _smtpClient;
        public string _server { get; set; }
        public  int _port { get; set; }
        public string _fromEmail { get; set; }
        public string _key { get; set; }
        public EmailService()
        {                    
            _smtpClient = new SmtpClient(_server, _port);          

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
