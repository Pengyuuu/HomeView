using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Managers.Contracts;
using Services.Contracts;
using Core.User;
using Services.Implementations;




namespace Managers.Implementations
{
    public class UserManager : IUserManager
    {
        private IUserService _userService;


        public UserManager()
        {
            _userService = new UserService();
        }

        // creates verified/confirmed user into user database
        public bool CreateVerifiedUser(string email, DateTime birth, string pw)
        {
            var user = new User();
            user.Email = email;
            user.Dob = birth;
            user.Password = pw;
            const int CREATION_MODE = 1;

            if (GetUser(user.Email) is null)
            {
                var isCreated = _userService.CreateUser(user, CREATION_MODE);
                if (isCreated)
                {
                    return true;
                }
            }
            return false;

        }

        // creates new, registered (unverified/unconfirmed) user into registration accounts database
        public bool CreateRegistrationUser(string email, DateTime birth, string pw)
        {
            var user = new User();
            user.Email = email;
            user.Dob = birth;
            user.Password = pw;
            const int CREATION_MODE = 0;

            if (GetUser(user.Email) is null)
            {
                var isCreated = _userService.CreateUser(user, CREATION_MODE);
                if (isCreated)
                {
                    return true;
                }
            }
            return false;

        }

        // Gets user
        public User GetUser(string email)
        {
            return _userService.GetUser(email);
        }

        public User DisplayGetUser(string display)
        {
            return _userService.DisplayGetUser(display);
        }

        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        public bool DeleteUser(string email)
        {
            return _userService.DeleteUser(email);
        }

        public User ModifyUser(User user)
        {
            return _userService.ModifyUser(user);

        }

        // Write to CSV File
        public String ExportAllUsers()
        {
            return _userService.ExportAllUsers();

        }


        // Bulk operation
        /* Modifies a user record in the system 
		 * if not found, then create
		 * what to do if want to delete?
		 * Returns a success or unsuccessful message
		 */
        public String DoBulkOp(string file)
        {
            return _userService.DoBulkOp(file);
        }
    }
}