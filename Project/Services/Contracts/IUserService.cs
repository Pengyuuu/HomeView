using Core.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public interface IUserService
    {
        Task<int> AsyncCreateUser(User userCreate, int CREATION_MODE);
        Task<int> AsyncCreateUserSession(User user, string jwtToken);
        Task<int> AsyncDeleteUser(string email, int DELETION_MODE);
        Task<User> AsyncDisplayGetUser(string display);
        Task<string> AsyncDoBulkOp(string file);
        Task<string> AsyncExportAllUsers();
        Task<List<User>> AsyncGetAllUsers();
        Task<User> AsyncGetRegisteredUser(string email);
        Task<User> AsyncGetUser(string email);
        Task<int> AsyncModifyUser(User user);
    }
}