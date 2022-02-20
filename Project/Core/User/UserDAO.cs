using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data;


namespace Core.User
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
        int userR = (int)user.UserRole;
        return _db.SaveData("dbo.InsertUser", new { user.FirstName, user.LastName, user.UserEmail, user.UserPassword, user.UserDob, user.DispName, user.RegDate, user.UserStatus, userR });
    }

    public Task UpdateUser(User user)
    {
            int userR = (int)user.UserRole;

            return _db.SaveData("dbo.UpdateUser", new { firstN = user.FirstName, user.LastName, user.UserEmail, user.UserPassword, user.UserDob, user.DispName, user.UserStatus, userR });
    }

    public Task<IEnumerable<User>> ReadUser(User user)
    {
            Task<IEnumerable<User>> results;
            try
            {
                results = _db.LoadData<User, dynamic>("dbo.GetUser", new { email = user.UserEmail });
            }
            catch (Exception e)
            {
                results = null;
            }
            return results;
    }

    public Task<IEnumerable<User>> ReadUser()
    {
            
            Task<IEnumerable<User>> results;
            try
            {
                results = _db.LoadData<User, dynamic>("dbo.GetAllUsers", "");
            }
            catch (Exception e)
            {
                results = null;
            }
            return results;
        }

    public Boolean DeleteUser(User user)
    {
            try
            {
                var result = _db.SaveData("dbo.DeleteUser", user.UserEmail);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
}
}
