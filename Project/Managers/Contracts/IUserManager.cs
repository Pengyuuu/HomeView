using System.Collections.Generic;
using Core.User;

namespace Managers.Contracts
{
    public interface IUserManager
    {
        bool CreateUser(User user);
        bool DeleteUser(string email);
        User DisplayGetUser(string display);
        string DoBulkOp(string file);
        string ExportAllUsers();
        List<User> GetAllUsers();
        User GetUser(string email);
        User ModifyUser(User user);
    }
}