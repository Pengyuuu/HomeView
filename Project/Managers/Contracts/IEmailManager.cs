using System.Threading.Tasks;

namespace Managers.Contracts
{
    public interface IEmailManager
    {
        Task<bool> AsyncSendConfirmationEmail(string registerEmail, string userOtp);
        Task<bool> AsyncSendRecoveryEmail(string email, string username);

    }
}