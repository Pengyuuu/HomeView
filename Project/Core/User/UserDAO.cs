using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data;
//using System;

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

        public async Task<int> AsyncCreateUser(User user, int CREATION_MODE)
        {
            // unverified, newly registered user
            if (CREATION_MODE == 0)
            {
                var person = new
                {
                    email = user.Email,
                    password = user.Password,
                    dob = user.Dob,
                    status = 0,
                    token = user.Token,
                    salt = user.Salt
                };

                return await _db.SaveData("dbo.RegisteredUsers_CreateUser", person);

            }
            // verified, confirmed user
            else if (CREATION_MODE == 1)
            {
                var person = new
                {
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    email = user.Email,
                    password = user.Password,
                    dob = user.Dob,
                    dispName = user.Email,
                    status = 1,
                    role = (int)user.Role,
                    token = user.Token,
                    salt = user.Salt
                };
                return await _db.SaveData("dbo.Users_CreateUser", person);

            }
            return 0;
        }

        public async Task<int> AsyncUpdateUser(User user)
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
                token = user.Token,
                salt = user.Salt
            };

            return await _db.SaveData("dbo.Users_UpdateUser", person);               
        }

        public async Task<User?> AsyncReadUser(string email)
        {
            var user = new
            {
                email = email
            };
            var results = await _db.LoadData<User, dynamic>("dbo.Users_ReadUser", user);                            
            return results.FirstOrDefault();              
        }

        public async Task<User?> AsyncReadRegisteredUser(string email)
        {
            var user = new
            {
                email = email
            };
            var results = await _db.LoadData<User, dynamic>("dbo.RegisteredUsers_ReadUser", user);
            return results.FirstOrDefault();

        }


        public async Task<User?> AsyncDisplayReadUser(string display)
        {
            var results = await _db.LoadData<User, dynamic>("dbo.Users_DisplayGetUser", new { dispName = display });
            return results.FirstOrDefault();
        }

        public async Task<IEnumerable<User>> AsyncReadAllUsers()
        {
            return await _db.LoadData<User, dynamic>("dbo.Users_GetAllUsers", new { });
        }

        public async Task<int> AsyncDeleteUser(string email, int DELETION_MODE)
        {
            var user = new
            {
                email = email
            };

            if (DELETION_MODE == 0)
            {
                return await _db.SaveData("dbo.Users_DeleteUser", user);
            }

            else if (DELETION_MODE == 1)
            {
                return await _db.SaveData("dbo.RegisteredUsers_DeleteUser", user);
            }

            return 0;
        }

        public async Task<int> AsyncCreateUserSession(User user, string jwtToken)
        {
            var userSession = new
            {
                email = user.Email,
                sessionToken = jwtToken
            };

            return await _db.SaveData("dbo.Sessions_CreateUserSession", userSession);     
            
        }
    }
}
