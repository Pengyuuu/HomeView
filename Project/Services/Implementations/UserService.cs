using System;
using System.Collections.Generic;
using System.Linq;
using Core.User;
using Core.Logging;
using System.IO;
using Services.Contracts;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private ILoggingService _loggingService;
        private UserDAO _userDAO;

        public UserService()
        {
            _loggingService = new LoggingService();
            _userDAO = new UserDAO();
        }

        // creates user given user fields and creation mode (either verified user, sent to user db, or unverified user, sent to accounts db )
        public bool CreateUser(User userCreate, int CREATION_MODE)
        {
            bool isCreated = false;
            try
            {
                isCreated = _userDAO.AsyncCreateUser(userCreate, CREATION_MODE).Result;
                Log userLog = new("User created.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogDataAsync(userLog);
            }
            catch
            {
                Log userLogFalse = new("Unsuccessful create user.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogDataAsync(userLogFalse);
                return false;
            }
            return isCreated;

        }

        // Gets user
        public User GetUser(string email)
        {
            User fetchedUser = (User)_userDAO.AsyncReadUser(email).Result;
            if (fetchedUser != null)
            {
                Log userLog = new("User found.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogDataAsync(userLog);
            }
            else
            {
                fetchedUser = (User)_userDAO.AsyncReadRegisteredUser(email).Result;
            }
            return fetchedUser;
        }

        // Gets registered user
        public User GetRegisteredUser(string email)
        {
            User fetchedUser = (User)_userDAO.AsyncReadRegisteredUser(email).Result;
            if (fetchedUser != null)
            {
                Log userLog = new("User found.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogDataAsync(userLog);
            }
            return fetchedUser;
        }


        public User DisplayGetUser(string display)
        {
            User fetchedUser = (User)_userDAO.AsyncDisplayReadUser(display).Result;
            if (fetchedUser != null)
            {
                Log userLog = new("User found.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogDataAsync(userLog);
            }
            return fetchedUser;
        }

        public List<User> GetAllUsers()
        {
            try
            {
                IEnumerable<User> fetchedUsers = _userDAO.AsyncReadAllUsers().Result;
                if (fetchedUsers != null)
                {

                    Log userLog = new("All users retrieved.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogDataAsync(userLog);
                }
                return fetchedUsers.ToList();
            }
            catch (Exception ex)
            {
                Log userLog = new("GetAllUsers failed " + ex.Message, LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogDataAsync(userLog);
            }
            return null;
        }

        public bool DeleteUser(string email, int DELETION_MODE)
        {

            User user = GetUser(email);
            if (user is not null)
            {
                var isDeleted = _userDAO.AsyncDeleteUser(email, DELETION_MODE).Result;
                if (isDeleted)
                {
                    Log userLogTrue = new("User: " + user.Email + " - successfully deleted.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogDataAsync(userLogTrue);
                    return true;
                }
            }
            Log userLogFalse = new("User: " + email + " - unsuccessful delete user.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
            _loggingService.LogDataAsync(userLogFalse);
            return false;
        }

        public User ModifyUser(User user)
        {
            User currentUser = GetUser(user.Email);
            if (user is not null && currentUser is not null)
            {
                var isUpdated = _userDAO.AsyncUpdateUser(user).Result;
                if (isUpdated)
                {
                    Log userLogSuccess = new("User: " + user.Email + " updated.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogDataAsync(userLogSuccess);
                    return GetUser(user.Email);
                }
            }
            else
            {
                const int CREATION_MODE = 1;
                CreateUser(user, CREATION_MODE);
                Log userLogCreate = new("User: " + user.Email + " could not be modified because it did not exist. Creating user.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogDataAsync(userLogCreate);
                return user;
            }
            Log userLogFail = new("User: " + user.Email + " was unable to be modified. ", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
            _loggingService.LogDataAsync(userLogFail);
            return null;

        }

        public bool CreateUserSession(User user, string jwtToken)
        {
            
            var isCreated = _userDAO.AsyncCreateUserSession(user, jwtToken).Result;
            if (isCreated)
            {
                Log userLogTrue = new("Successfully created user session.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogDataAsync(userLogTrue);
                return true;
            }           
            Log userLogFalse = new("Unsuccessful create user session", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
            _loggingService.LogDataAsync(userLogFalse);
            return false;
        }

        // Write to CSV File
        public String ExportAllUsers()
        {
            var userList = _userDAO.AsyncReadAllUsers().Result;
            string filePath = Path.GetFullPath("@\\..\\..\\..\\..\\..\\..\\Project\\Data\\ExportedUserData.csv");
            Log userLog;

            if (userList != null)
            {
                try
                {
                    File.WriteAllText(filePath, userList.ToString());
                }
                catch (Exception e)
                {
                    return "Unable to export all users.";
                }

                userLog = new("Exported all users to .csv", LogLevel.Info, LogCategory.View, DateTime.Now);
                _loggingService.LogDataAsync(userLog);
                return "User data successfully exported to .csv file";
            }

            userLog = new("Unable to export all users to file.", LogLevel.Error, LogCategory.View, DateTime.Now);
            _loggingService.LogDataAsync(userLog);
            return "Unable to export all users.";

        }


        // Bulk operation
        /* Modifies a user record in the system 
		 * if not found, then create
		 * what to do if want to delete?
		 * Returns a success or unsuccessful message
		 */
        public String DoBulkOp(string file)
        {
            Log userLog = new();


            List<String> mods = File.ReadAllLines(file).Skip(1).ToList();
            string sysMessage = "";
            int successMods = 0;
            int failedMods = 0;

            foreach (String csvLine in mods)
            {
                string[] delimiter = csvLine.Split('|');
                User userMod = new User();
                string mode = delimiter[0];
                userMod.FirstName = delimiter[1];
                userMod.LastName = delimiter[2];
                userMod.Email = delimiter[3];
                userMod.Password = delimiter[4];
                userMod.Dob = Convert.ToDateTime(delimiter[5]);
                userMod.DispName = delimiter[6];
                userMod.Status = Convert.ToBoolean(delimiter[7]);
                userMod.Role = (Role)(Convert.ToInt16(delimiter[8]));
                const int CREATION_MODE = 1;
                const int DELETION_MODE = 1;


                if (userMod is not null)
                {

                    try
                    {
                        if (mode == "Create")
                        {
                            CreateUser(userMod, CREATION_MODE);
                        }
                        else if (mode == "Modify")
                        {
                            ModifyUser(userMod);
                        }
                        else if (mode == "Delete")
                        {
                            DeleteUser(userMod.Email, DELETION_MODE);
                        }
                        successMods++;
                    }
                    catch
                    {
                        failedMods++;
                    }
                }
            }
            sysMessage = "Successfully modified " + successMods + ".\n Failed to modify: " + failedMods + ".\n";
            return sysMessage;
        }
    }
}
