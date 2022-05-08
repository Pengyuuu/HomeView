using System;
using System.Collections.Generic;
using System.Linq;
using Core.User;
using Core.Logging;
using System.IO;
using Services.Contracts;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ILoggingService _loggingService;
        private readonly UserDAO _userDAO;

        public UserService()
        {
            _loggingService = new LoggingService();
            _userDAO = new UserDAO();
        }

        // creates user given user fields and creation mode (either verified user, sent to user db, or unverified user, sent to accounts db )
        public async Task<int> AsyncCreateUser(User userCreate, int CREATION_MODE)
        {
            int createdUser = 0;

            createdUser = await _userDAO.AsyncCreateUser(userCreate, CREATION_MODE);
            if (createdUser == 1)
            {
                Log userLog = new("User created.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);

                await _loggingService.LogDataAsync(userLog);
            }
            else
            {
                Log userLogFalse = new("Unsuccessful create user.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);

                await _loggingService.LogDataAsync(userLogFalse);

            }
            return createdUser;

        }

        // Gets user
        public async Task<User> AsyncGetUser(string email)
        {
            User fetchedUser = await _userDAO.AsyncReadUser(email);
            if (fetchedUser != null)
            {
                Log userLog = new("User found.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);

                await _loggingService.LogDataAsync(userLog);
            }
            else
            {
                Log userLogFalse = new("User not found.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(userLogFalse);
            }
            return fetchedUser;
        }

        // Gets registered user
        public async Task<User> AsyncGetRegisteredUser(string email)
        {
            User fetchedUser = (User)_userDAO.AsyncReadRegisteredUser(email).Result;
            if (fetchedUser != null)
            {
                Log userLog = new("User found.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);

                await _loggingService.LogDataAsync(userLog);
            }
            return fetchedUser;
        }

        public async Task<User> AsyncDisplayGetUser(string display)
        {
            User fetchedUser = (User)_userDAO.AsyncDisplayReadUser(display).Result;
            if (fetchedUser != null)
            {
                Log userLog = new("User found.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);

                await _loggingService.LogDataAsync(userLog);
            }
            return fetchedUser;
        }

        public async Task<List<User>> AsyncGetAllUsers()
        {

            IEnumerable<User> fetchedUsers = await _userDAO.AsyncReadAllUsers();
            if (fetchedUsers != null)
            {

                Log userLog = new("All users retrieved.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(userLog);
                
            }
            else
            {
                Log userLog = new("GetAllUsers failed ", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(userLog);
            }
            return fetchedUsers.ToList();
        }

        public async Task<int> AsyncDeleteUser(string email, int DELETION_MODE)
        {
            User user = await AsyncGetUser(email);
            int isDeleted = await _userDAO.AsyncDeleteUser(email, DELETION_MODE);
            if (isDeleted == 1)
            {
                Log userLogTrue = new("User: " + user.Email + " - successfully deleted.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(userLogTrue);
            }
            else
            {
                Log userLogFalse = new("User: " + email + " - unsuccessful delete user.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(userLogFalse);
            }
            return isDeleted;

        }

        public async Task<int> AsyncModifyUser(User user)
        {
            User currentUser = await AsyncGetUser(user.Email);
            int isUpdated = 0;

            if (user is not null && currentUser is not null)
            {
                isUpdated = await _userDAO.AsyncUpdateUser(user);
                if (isUpdated == 1)
                {
                    Log userLogSuccess = new("User: " + user.Email + " updated.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                    await _loggingService.LogDataAsync(userLogSuccess);
                }
                else
                {
                    Log userLogFail = new("User: " + user.Email + " was unable to be modified. Database error. ", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                    await _loggingService.LogDataAsync(userLogFail);

                }
            }
            else
            {
                Log userLogFail = new("User: " + user.Email + " was unable to be modified. ", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(userLogFail);
            }
            return isUpdated;


        }

        public async Task<int> AsyncCreateUserSession(User user, string jwtToken)
        {

            var isCreated = await _userDAO.AsyncCreateUserSession(user, jwtToken);
            if (isCreated == 1)
            {
                Log userLogTrue = new("Successfully created user session.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(userLogTrue);

            }
            else
            {
                Log userLogFalse = new("Invalid login. Unsuccessful create user session", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(userLogFalse);
            }
            return isCreated;

        }

        // Write to CSV File
        public async Task<String> AsyncExportAllUsers()
        {
            var userList = await _userDAO.AsyncReadAllUsers();
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
                await _loggingService.LogDataAsync(userLog);

                return "User data successfully exported to .csv file";
            }

            userLog = new("Unable to export all users to file.", LogLevel.Error, LogCategory.View, DateTime.Now);
            await _loggingService.LogDataAsync(userLog);

            return "Unable to export all users.";

        }


        // Bulk operation
        /* Modifies a user record in the system 
		 * if not found, then create
		 * what to do if want to delete?
		 * Returns a success or unsuccessful message
		 */
        public async Task<String> AsyncDoBulkOp(string file)
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
                            await AsyncCreateUser(userMod, CREATION_MODE);
                        }
                        else if (mode == "Modify")
                        {
                            await AsyncModifyUser(userMod);
                        }
                        else if (mode == "Delete")
                        {
                            await AsyncDeleteUser(userMod.Email, DELETION_MODE);
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

        // 
        /* Gets count of registered users on a certain day
		 */
        public async Task<int> AsyncGetRegistrationCount(DateTime date)
        {
            return await _userDAO.AsyncGetRegisteredCount(date);
        }

    }
}
