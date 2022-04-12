using Core.User;

namespace Services.Contracts
{
    public interface IRegistrationService
    {
        bool CreateUser(User userCreate, int CREATION_MODE);
    }
}