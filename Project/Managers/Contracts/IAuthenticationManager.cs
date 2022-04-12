namespace Managers.Contracts
{
    public interface IAuthenticationManager
    {
        string GenerateOTP();
        bool AuthenticateUser(string email, string userOtp);

    }
}