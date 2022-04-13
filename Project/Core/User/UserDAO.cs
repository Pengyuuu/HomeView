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

        public async Task<bool> AsyncCreateUser(User user, int CREATION_MODE)
        {
            // unverified, newly registered user
            if (CREATION_MODE == 0)
            {
                var person = new
                {
                    email = user.Email,
                    password = user.Password,
                    dob = user.Dob,
                    token = user.Token,
                    status = 0
                };

                try
                {
                    await _db.SaveData("dbo.RegisteredUsers_CreateUser", person);
                    return true;
                }
                catch
                {
                    return false;
                }
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
                    token = user.Token
                };

                try
                {
                    await _db.SaveData("dbo.Users_CreateUser", person);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
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
                await _db.SaveData("dbo.Users_UpdateUser", person);               
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
                var results = await _db.LoadData<User, dynamic>("dbo.Users_ReadUser", user);             
                
                return results.FirstOrDefault();
                
            }
            catch
            {
                return null;
            }
        }

        public async Task<User?> AsyncReadRegisteredUser(string email)
        {
            var user = new
            {
                email = email
            };
            try
            {
                var results = await _db.LoadData<User, dynamic>("dbo.RegisteredUsers_ReadUser", user);

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
                var results = await _db.LoadData<User, dynamic>("dbo.Users_DisplayGetUser", new { dispName = display });
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
                return await _db.LoadData<User, dynamic>("dbo.Users_GetAllUsers", new { });
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AsyncDeleteUser(string email, int DELETION_MODE)
        {
            var user = new
            {
                email = email
            };
            if (DELETION_MODE == 0)
            {
                try
                {
                    await _db.SaveData("dbo.Users_DeleteUser", user);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else if (DELETION_MODE == 1)
            {
                try
                {
                    await _db.SaveData("dbo.RegisteredUsers_DeleteUser", user);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
