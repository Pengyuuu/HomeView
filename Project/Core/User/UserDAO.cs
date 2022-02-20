using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data;


namespace User
{
    public class UserDAO
{

    private readonly SqlDataAccess _db;

    public UserDAO(UMService service)
    {
    }

    public UserDAO(SqlDataAccess db)
    {
        _db = db;
    }

    public Task CreateUser(User user)
    {
        return _db.SaveData("dbo.InsertUser", new { user.FirstName, user.LastName, user.UserEmail, user.UserPassword, user.UserDob, user.DispName, user.RegDate, user.UserStatus, ((int)user.UserRole) });
    }

    public Task UpdateUser(User user)
    {
        return _db.SaveData("dbo.UpdateUser", new { firstN = user.FirstName, user.LastName, user.UserEmail, user.UserPassword, user.UserDob, user.DispName, user.RegDate, user.UserStatus, ((int)user.UserRole) });
    }

    public Task ReadUser(User user)
    {
        var results = _db.LoadData<User, dynamic>("dbo.GetUser", new { email = user.UserEmail });
            return results;
    }

    public Task<IEnumerable<User>> ReadUser()
    {
        var result = _db.LoadData<User, dynamic>("dbo.GetAllUsers", "");
            return result;
    }

    public Task DeleteUser(User user)
    {
        return _db.SaveData("dbo.DeleteUser", user.UserEmail);
    }
}
}
