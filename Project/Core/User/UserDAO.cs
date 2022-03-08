using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data;
using System;

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
            var p = new
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                email = user.Email,
                password = user.Password,
                dob = user.Dob,
                dispName = user.Email,
                role = (int) user.Role,
                status = 0,
                token = user.Token
            };
            return _db.SaveData("dbo.Users_CreateUser", p);
        }

        public Task UpdateUser(User user)
        {
            var p = new
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                email = user.Email,
                password = user.Password,
                dob = user.Dob,
                dispName = user.DispName,
                status = user.Status,
                role = (int) user.Role,
                token = user.Token
            };
            return _db.SaveData("dbo.Users_UpdateUser", p);
        }

        public async Task<User?> ReadUser(string email)
        {
            var p = new
            {
                email = email
            };
            var results = await _db.LoadData<User, dynamic>("dbo.Users_ReadUser", p);
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
            var p = new
            {
                email = email
            };
            return _db.SaveData("dbo.Users_DeleteUser", p);
        }
    }
}
