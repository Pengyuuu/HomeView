using Core.User;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IRegistrationService
    {
        Task<int> CreateUserAsync(User userCreate, int CREATION_MODE);
    }
}