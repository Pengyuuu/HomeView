using Core.User;
using System.Collections.Generic;

namespace Services.Contracts
{
    public interface IUserService
    {
        bool CreateUser(User userCreate, int CREATION_MODE);
        bool DeleteUser(string email, int DELETION_MODE);
        User DisplayGetUser(string display);
        string DoBulkOp(string file);
        string ExportAllUsers();
        List<User> GetAllUsers();
        User GetUser(string email);
        User GetRegisteredUser(string email);
        User ModifyUser(User user);
    }
}