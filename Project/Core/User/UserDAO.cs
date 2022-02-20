/*using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;




namespace UM.User
{
    public class UserDAO
{

    private readonly ISqlDataAccess _db;

    public UserDAO(UMService service)
    {
    }

    public UserDAO(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task CreateUser(User user)
    {
        _db.SaveData("dbo.InsertUser", new { user.FirstName, user.LastName, user.UserEmail, user.UserPassword, user.UserDob, user.DispName, user.RegDate, user.UserStatus, ((int)user.UserRole) });
    }

    public Task UpdateUser(User user)
    {
        _db.SaveData("dbo.UpdateUser", new { firstN = user.FirstName, user.LastName, user.UserEmail, user.UserPassword, user.UserDob, user.DispName, user.RegDate, user.UserStatus, ((int)user.UserRole) });
    }

    public Task ReadUser(User user)
    {
        var results = _db.LoadData<User, dynamic>("dbo.GetUser", new { email = user.UserEmail });
        return results.FirstOrDefault();
    }

    public Task<IEnumerable<User>> ReadUser()
    {
        _db.LoadData<User, dynamic>("dbo.GetAllUsers", new { });
    }

    public Task DeleteUser(User user)
    {
        _db.SaveData("dbo.DeleteUser", new { user.UserEmail });
    }
}
}
*/