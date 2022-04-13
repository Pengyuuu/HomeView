namespace Managers.Contracts
{
    public interface IAuthenticationManager
    {
        string GenerateOTP();
        bool AuthenticateRegisteredUser(string email, string userOtp);
        bool AuthenticateLogInUser(string email, string userOtp);


    }
}