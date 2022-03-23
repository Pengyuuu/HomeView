namespace Managers.Contracts
{
    public interface IRegistrationManager
    {
        bool CreateUser(string email, string dob, string pw);
        bool ValidateBirth(string dob);
        bool ValidateEmail(string email);
        bool ValidateFields(string email, string dob, string pw);
        bool ValidatePassword(string password);
    }
}