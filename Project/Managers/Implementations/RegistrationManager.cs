using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    public class RegistrationManager
    {
        private UserManager _userManager;

        public RegistrationManager()
        {
            _userManager = new UserManager();
        }

        public bool ValidateEmail(string email)
        {
            if (email != null)
            {
                //  makes sure new user's email is valid (contains @.com)
                if (email.Contains("@") && email.Contains(".com"))
                {
                    // check if in db
                    if (_userManager.GetUser(email))
                    {

                    }
                }

                return false;
            }
            return false;
        }

        public bool ValidateFields(string email, string fname, string lname, string pw)
        {
            if (email != null && fname != null && lname != null && pw != null)
            {
                //  makes sure new user's email is valid (contains @.com)
                if (email.Contains("@") == email.Contains(".com")) {

                    // makes sure new user's password is valid (contains minimum of 12 characters, at least 1 capital letter, at least 1 non-alphanumeric character
                    int pwMinLength = 12;
                    Boolean containsUpper = false;
                }

                return false;
            }
            return false;

        }

        public bool CreateUser(User user)
        {
            if (GetUser(user.Email) is null)
            {
                _userDAO.CreateUser(user);
                return true;
            }
            return false;

        }

        // Gets user
        public User GetUser(string email)
        {
            User u = (User)_userDAO.ReadUser(email).Result;
            Log userLog = new("User found.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
            _loggingManager.LogData(userLog);
            return u;
        }
    }
}
