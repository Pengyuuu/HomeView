using Core.User;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IRegistrationService
    {
        Task<int> AsyncCreateUser(User userCreate, int CREATION_MODE);
    }
}