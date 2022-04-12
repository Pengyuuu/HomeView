using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<string> AsyncGenerateOTP();
        bool AuthenticateUser(string email, string userOtp);

    }
}