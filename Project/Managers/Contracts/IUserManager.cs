using Core.User;
using System.Collections.Generic;

namespace Managers.Contracts
{
    public interface IUserManager
    {
        bool CreateUser(string email, string birth, string pw);
        bool DeleteUser(string email);
        User DisplayGetUser(string display);
        string DoBulkOp(string file);
        string ExportAllUsers();
        List<User> GetAllUsers();
        User GetUser(string email);
        User ModifyUser(User user);
    }
}