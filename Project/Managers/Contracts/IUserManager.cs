using Core.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Managers.Contracts
{
    public interface IUserManager
    {
        Task<int> AsyncCreateRegistrationUser(string email, DateTime birth, string pw);
        Task<int> AsyncCreateVerifiedUser(string email, DateTime birth, string pw, string salt);
        Task<int> AsyncDeleteRegistrationUser(string email);
        Task<int> AsyncDeleteVerifiedUser(string email);
        Task<string> AsyncDoBulkOp(string file);
        Task<string> AsyncExportAllUsers();
        Task<List<User>> AsyncGetAllUsers();
        Task<User> AsyncGetUser(string email);
        Task<int> AsyncModifyUser(User user);
        Task<User> DisplayGetUser(string display);
    }
}