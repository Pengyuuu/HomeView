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
            return _db.SaveData("dbo.Users_CreateUser", 
                new {firstN = user.FirstName, 
                    lastN = user.LastName, 
                    email = user.Email, 
                    pw = user.Password, 
                    dob = user.Dob, 
                    dispN = user.DispName, 
                    status = user.Status, 
                    role = user.Role });
        }

        public Task UpdateUser(User user)
        {
            int userR = (int)user.Role;
            return _db.SaveData("dbo.Users_UpdateUser", user);
        }

        public async Task<User?> ReadUser(string email)
        {
            var results = await _db.LoadData<User, dynamic>("dbo.Users_ReadUser", new { email = email});
            return results.FirstOrDefault();
        }

        public async Task<User?> DisplayReadUser(string display)
        {
            var results = await _db.LoadData<User, dynamic>("dbo.Users_DisplayGetUser", new { dispName = display});
            return results.FirstOrDefault();
        }

        public Task<IEnumerable<User>> ReadAllUsers()
        {
            return _db.LoadData<User, dynamic>("dbo.Users_GetAllUsers", new { });
        }

        public Task DeleteUser(string email)
        {
            return _db.SaveData("dbo.Users_DeleteUser", new {email = email});
        }
    }
}
