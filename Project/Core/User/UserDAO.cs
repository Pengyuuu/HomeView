using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data;
using System;
using Dapper;

namespace Core.User
{
    public class UserDAO
    {

        private readonly SqlDataAccess _db;

        public UserDAO()
        {
            _db = new SqlDataAccess();
        }

        public UserDAO(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AsyncCreateUser(User user)
        {
            /**
            var person = new
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                email = user.Email,
                password = user.Password,
                dob = user.Dob,
                dispName = user.Email,
                status = 0,                             
                regDate = DateTime.Now,
                role = (int)user.Role,
                token = user.Token
            };**/
            var p = new DynamicParameters();
            p.Add("?firstName?", user.FirstName);
            p.Add("?lastName?", user.LastName);
            p.Add("?email?", user.Email);
            p.Add("?password?", user.Password);
            p.Add("?dob?", user.Dob);
            p.Add("?dispName?", user.DispName);
            p.Add("?status?", user.Status);
            p.Add("?regDate?", user.RegDate);
            p.Add("?role?", Convert.ToInt32(user.Role));
            p.Add("?token?", "");


            try
            {
                await _db.SaveData("Users_CreateUser", p);               
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> AsyncUpdateUser(User user)
        {
            var person = new
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
            try
            {
                await _db.SaveData("Users_UpdateUser", person);               
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<User?> AsyncReadUser(string email)
        {
            var user = new
            {
                email = email
            };
            try
            {
                var results = await _db.LoadData<User, dynamic>("Users_Email_GetUser", user);
                return results.FirstOrDefault();

            }
            catch
            {
                return null;
            }
        }

        public async Task<User?> AsyncDisplayReadUser(string display)
        {
            try
            {
                var results = await _db.LoadData<User, dynamic>("Users_DisplayName_GetUser", new { dispName = display });
                return results.FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<User>> AsyncReadAllUsers()
        {
            try
            {
                return await _db.LoadData<User, dynamic>("dbo.Users_GetAllUsers ?", new { });
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AsyncDeleteUser(string email)
        {
            var user = new
            {
                email = email
            };
            try
            {
                await _db.SaveData("Users_DeleteUser", user);
                return true;
            }
            catch
            {
                return false;
            }           
        }
    }
}
