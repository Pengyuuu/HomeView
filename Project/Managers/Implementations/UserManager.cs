using System;
using System.Collections.Generic;
using Managers.Contracts;
using Services.Contracts;
using Core.User;
using Services.Implementations;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    public class UserManager : IUserManager
    {
        private IUserService _userService;
        private IAuthenticationService _authenticationService;

        public UserManager()
        {
            _userService = new UserService();
            _authenticationService = new AuthenticationService();
        }

        // creates verified/confirmed user into user database
        public async Task<int> AsyncCreateVerifiedUser(string email, DateTime birth, string pw, string salt)
        {
            var user = new User();
            user.Email = email;
            user.Dob = birth;
            //string salt = _authenticationService.GenerateSalt();
            user.Salt = salt;
            //user.Password = _authenticationService.HashPassword(pw, salt);
            user.Password = pw;
            const int CREATION_MODE = 1;

            return await _userService.AsyncCreateUser(user, CREATION_MODE);


        }

        // creates new, registered (unverified/unconfirmed) user into registration accounts database
        public async Task<int> AsyncCreateRegistrationUser(string email, DateTime birth, string pw)
        {
            var user = new User();
            user.Email = email;
            user.Dob = birth;
            string salt = _authenticationService.GenerateSalt();
            user.Salt = salt;
            user.Password = _authenticationService.HashPassword(pw, salt);
            user.Password = pw;
            const int CREATION_MODE = 0;

            return await _userService.AsyncCreateUser(user, CREATION_MODE);

        }

        // Gets user
        public async Task<User> AsyncGetUser(string email)
        {
            return await _userService.AsyncGetUser(email);
        }

        public async Task<User> DisplayGetUser(string display)
        {
            return await _userService.AsyncDisplayGetUser(display);
        }

        public async Task<List<User>> AsyncGetAllUsers()
        {
            return await _userService.AsyncGetAllUsers();
        }

        public async Task<int> AsyncDeleteVerifiedUser(string email)
        {
            const int DELETION_MODE = 0;
            return await _userService.AsyncDeleteUser(email, DELETION_MODE);

        }

        public async Task<int> AsyncDeleteRegistrationUser(string email)
        {
            const int DELETION_MODE = 1;
            return await _userService.AsyncDeleteUser(email, DELETION_MODE);

        }

        public async Task<int> AsyncModifyUser(User user)
        {
            return await _userService.AsyncModifyUser(user);


        }

        // Write to CSV File
        public async Task<String> AsyncExportAllUsers()
        {
            return await _userService.AsyncExportAllUsers();

        }


        // Bulk operation
        /* Modifies a user record in the system 
		 * if not found, then create
		 * what to do if want to delete?
		 * Returns a success or unsuccessful message
		 */
        public async Task<String> AsyncDoBulkOp(string file)
        {
            return await _userService.AsyncDoBulkOp(file);
        }
    }
}