﻿namespace Managers.Implementations
{
    public interface IUserManager
    {
        bool CreateUser(string email, string birth, string pw);
        bool CreateUser(User userCreate);
        bool DeleteUser(string email);
        User DisplayGetUser(string display);
        string DoBulkOp(string file);
        string ExportAllUsers();
        System.Collections.Generic.List<User> GetAllUsers();
        User GetUser(string email);
        User ModifyUser(User user);
    }
}