namespace Managers.Contracts
{
    public interface IEmailManager
    {
        bool SendConfirmationEmail(string registerEmail);
    }
}