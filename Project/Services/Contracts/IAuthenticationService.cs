using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAuthenticationService
    {
        string GenerateJWTToken(string email);
        string GenerateOTP();
        bool AuthenticateRegisteredUser(string email, string userOtp);
        bool AuthenticateLogInUser(string email, string pw);

        //string HashPassword(string pw, string salt);
        
        //string GenerateSalt();
    }
}