namespace Managers.Contracts
{
    public interface IAuthenticationManager
    {
        string AuthenticateLogInUser(string email, string pw);
        bool AuthenticateRegisteredUser(string email, string userOtp);
        string GenerateJWTToken(string email);
        string GenerateOTP();
        string GetSalt();
        string HashPassword(string pw, string salt);
    }
}