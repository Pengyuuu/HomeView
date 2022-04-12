using System.Net.Mail;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IEmailService
    {
        Task<bool> AsyncSendEmail(MailMessage message);
    }
}