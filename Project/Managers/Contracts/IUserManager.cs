using Core.User;
using System;
using System.Collections.Generic;

namespace Managers.Contracts
{
    public interface IUserManager
    {
        bool CreateRegistrationUser(string email, DateTime birth, string pw);
        bool CreateVerifiedUser(string email, DateTime birth, string pw);
        bool DeleteRegistrationUser(string email);
        bool DeleteVerifiedUser(string email);
        User DisplayGetUser(string display);
        string DoBulkOp(string file);
        string ExportAllUsers();
        List<User> GetAllUsers();
        User GetUser(string email);
        User ModifyUser(User user);
    }
}