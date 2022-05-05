using Core.User;
using System.Threading.Tasks;

namespace Managers.Contracts
{
    public interface IAccountRecoveryManager
    {
        Task<bool> AsyncCheckValidRecovery(User recoverUser);
        Task<string> AsyncSendRecoveryEmail(User recoverUser);
    }
}