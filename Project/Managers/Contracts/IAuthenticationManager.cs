namespace Managers.Contracts
{
    public interface IAuthenticationManager
    {
        string GenerateJWTToken(string email);
        string GenerateOTP();
        bool AuthenticateRegisteredUser(string email, string userOtp);
        bool AuthenticateLogInUser(string email, string pw);


    }
}