using System.Threading.Tasks;

namespace Managers.Contracts
{
    public interface IRegistrationManager
    {
        Task<bool> AsyncCreateUser(string email, string birth, string pw);
        bool ValidateBirth(string dob);
        bool ValidateEmail(string email);
        bool ValidateFields(string email, string dob, string pw);
        bool ValidatePassword(string password);
    }
}