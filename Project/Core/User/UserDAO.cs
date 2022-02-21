using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data;


namespace Core.User
{
    public class UserDAO
    {

        private readonly SqlDataAccess _db;

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

        public async Task<User?> ReadUser(string email)
        {
            var results = await _db.LoadData<User, dynamic>("dbo.GetUser", new { email = email});
            return results.FirstOrDefault();
        }

        public Task<IEnumerable<User>> ReadAllUsers()
        {
            return _db.LoadData<User, dynamic>("dbo.GetAllUsers", "");
        }

        public Task DeleteUser(string email)
        {
            return _db.SaveData("dbo.DeleteUser", email);
        }
    }
}
