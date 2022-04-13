using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<string> AsyncGenerateOTP();
        bool AuthenticateRegisteredUser(string email, string userOtp);
        bool AuthenticateLogInUser(string email, string pw);


    }
}