using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data;
using System;
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

        public async Task<int> CreateUserAsync(User user, int CREATION_MODE)
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
                    salt = user.Salt,
                    blacklistToggle = user.BlacklistToggle,
                    firstTimer = 1

                };
                return await _db.SaveData("dbo.Users_CreateUser", person);

            }
            return 0;
        }

        public async Task<int> UpdateUserAsync(User user)
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
                salt = user.Salt,
                blacklistToggle = user.BlacklistToggle,
                firstTimer = user.FirstTimer
            };

            return await _db.SaveData("dbo.Users_UpdateUser", person);               
        }

        public async Task<User?> ReadUserAsync(string email)
        {
            var user = new
            {
                email = email
            };
            var results = await _db.LoadData<User, dynamic>("dbo.Users_ReadUser", user);                            
            return results.FirstOrDefault();              
        }

        public async Task<User?> ReadRegisteredUserAsync(string email)
        {
            var user = new
            {
                email = email
            };
            var results = await _db.LoadData<User, dynamic>("dbo.RegisteredUsers_ReadUser", user);
            return results.FirstOrDefault();

        }


        public async Task<User?> DisplayReadUserAsync(string display)
        {
            var results = await _db.LoadData<User, dynamic>("dbo.Users_DisplayGetUser", new { dispName = display });
            return results.FirstOrDefault();
        }

        public async Task<IEnumerable<User>> ReadAllUsersAsync()
        {
            return await _db.LoadData<User, dynamic>("dbo.Users_GetAllUsers", new { });
        }

        public async Task<int> DeleteUserAsync(string email, int DELETION_MODE)
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

            return -1;
        }

        public async Task<int> CreateUserSessionAsync(User user, string jwtToken)
        {
            var userSession = new
            {
                email = user.Email,
                sessionToken = jwtToken
            };

            return await _db.SaveData("dbo.Sessions_CreateUserSession", userSession);     
            
        }

        public async Task<int> GetRegisteredCountAsync(DateTime date)
        {
            var selectedDate = new
            {
                regDate = date
            };

            var result = await _db.LoadData<int, dynamic>("dbo.RegisteredUsers_GetCountDate", selectedDate);
            if (result.Count() == 1)
            {
                return result.FirstOrDefault();
            }
            return -1;
        }        
    }
}
