using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Logging.Logging;


/* User Authentication and Authorization Manager */
namespace UM.User {
	public class UserManager
	{
		private String SYS_ADMIN = "TeamUnite";
		private String SYS_PASS = "Testing";
		private UMService _umService;
		private Boolean _isVerified = false;


		public UserManager(string adminInput, string passInput)
		{
			_umService = new UMService(this);
			_isVerified = IsVerifiedAdmin(adminInput, passInput);
		}

		/* Verifies if actor is system administrator 
		 * Returns: true if matches, false if doesn't match
		 */
		public Boolean IsVerifiedAdmin(string adminInput, string passInput)
		{
			Log adminLog = new ("verifying admin", LogLevel.Info, LogCategory.View, DateTime.Now);
			LoggingManager logManager = new LoggingManager();
			logManager.LogData(adminLog);

			// checks if input matches system admin info
			Boolean isAdminUser = adminInput == this.SYS_ADMIN;	
			Boolean isPass = passInput == this.SYS_PASS;
			return isAdminUser == isPass;
		}

		/* Ensures that New user has entered correct fields 
		 *	Checks for valid userEmail address, valid password */
		public Boolean IsNewUser(User u)
		{
			Log userLog = new("checking user in database", LogLevel.Info, LogCategory.Data, DateTime.Now);
			LoggingManager logManager = new LoggingManager();
			logManager.LogData(userLog);

			//  makes sure new user's userEmail is valid (contains @.com)
			string userEmail = u.UserEmail;
			Boolean isValidEmail = (userEmail.Contains("@") == userEmail.Contains(".com"));

			// makes sure new user's password is valid (contains minimum of 12 characters, at least 1 capital letter, at least 1 non-alphanumeric character
			string userPass = u.UserPassword;
			int passMinLength = 12;
			Boolean containsUpper = false;
			Boolean containsNonAlpha = false;
			Boolean hasLength = false;

			// ensures password meets length requirement
			if (userPass.Length >= passMinLength)
			{
				hasLength = true;
			}

			// ensures pasword meets capital and non-alphanumeric requirement
			for (int i = 0; i < userPass.Length; i++)
			{
				if (Char.IsUpper(userPass[i]))
				{
					containsUpper = true;
				}

				if (!Char.IsLetterOrDigit(userPass[i]))
				{
					containsNonAlpha = true;
				}
			}

			return (isValidEmail == containsUpper == containsNonAlpha == hasLength);

		}

		// Gets user
		public String GetUser(string userEmail)
        {
			Log userLog = new();
			LoggingManager logManager = new LoggingManager();
			if (!this._isVerified)
			{
				userLog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);

				return "Unauthorized access";
			}

			if (!_umService.IsUser(userEmail))
            {
				userLog = new("User does not exist", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);

				return "User does not exist";
            }

			userLog = new("User found.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);

			User fetchedUser = this._umService.UMServiceGetUser(userEmail);

			return fetchedUser.ToString();

        }

		public String GetAllUsers()
		{
			Log userLog = new();
			LoggingManager logManager = new LoggingManager();

			if (!this._isVerified)
			{
				userLog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "Unauthorized access";
			}

			userLog = new("Fetching all users.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);
			return this._umService.GetAllUsers();

		}

		public String ExportAllUsers()
		{
			Log userLog = new();
			LoggingManager logManager = new LoggingManager();
			if (!this._isVerified)
			{
				userLog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "Unauthorized access";
			}

			if (!this._umService.ExportAllUsers()) {
				userLog = new("Unable to export all users to file.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "Unable to export all users.";
            }

			userLog = new("Exported all users to .csv", LogLevel.Info, LogCategory.View, DateTime.Now);
			logManager.LogData(userLog);
			return "User data successfully exported to .csv file";

		}

		/* Modifies a user record in the system 
		 * 1 = Update information
		 * 2 = Delete account
		 * 3 = Disable
		 * 4 = Enable
		 * 5 = Create
		 * Returns a success or unsuccessful message
		 */
		public String ModifyUser(string userEmail, int mode, User userMod)
		{
			Log userLog = new();
			LoggingManager logManager = new LoggingManager();
			// if user is not admin, returns unauthorized access
			if (!this._isVerified)
			{
				userLog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "Unauthorized access.";
			}

			if (!this._umService.IsUser(userEmail))
            {
				userLog = new("User does not exist", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "User does not exist.";
            }

			userLog = new("Modifying user", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);
			// calls service layer to modify user
			string sysMessage = this._umService.CanModifyUser(userEmail, mode, userMod) == true ? "User account modification successful." : "Account modification unsuccessful.";
			userLog = new(sysMessage, LogLevel.Error, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);

			return sysMessage;
		}

		// Bulk operation
		/* Modifies a user record in the system 
		 * 1 = Update information
		 * 2 = Delete account
		 * 3 = Disable
		 * 4 = Enable
		 * 5 = Create
		 * Returns a success or unsuccessful message
		 */
		public String ModifyUsers(string file)
        {
			Log userLog = new();
			LoggingManager logManager = new LoggingManager();
			// if user is not admin, returns unauthorized access
			if (!this._isVerified)
			{
				userLog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "Unauthorized access.";
			}

			List <String> mods = File.ReadAllLines(file).Skip(1).ToList();
			
			string sysMessage = "";
			int successMods = 0;
			int failedMods = 0;

			foreach(String csvLine in mods)
            {
				
				string[] delimiter = csvLine.Split(',');
				int id = Convert.ToInt32(delimiter[0]);
				int mode = Convert.ToInt32(delimiter[1]);

				User userMod = new User();
				string mfirstName = delimiter[3];
				string mlastName = delimiter[4];
				string memail = delimiter[5];
				string mpassword = delimiter[6];
				DateTime mdob = Convert.ToDateTime(delimiter[7]);
				string mdispName = delimiter[8];
				int mstatus = Convert.ToInt16(delimiter[10]);
				Role mr = (Role) (Convert.ToInt16(delimiter[11]));

				userMod.UpdateUser(mfirstName, mlastName, memail, mpassword, mdob, mdispName, mstatus, mr);


				sysMessage = ModifyUser(memail, mode, userMod);

				if (sysMessage == "Invalid inputs for new user.")
                {
					userLog = new("Invalid inputs for new user. ", LogLevel.Error, LogCategory.Data, DateTime.Now);
					logManager.LogData(userLog);
					return ("Invalid inputs for new user id: " + id);
                }
				else if (sysMessage == "Account modification unsuccessful.")
                {
					userLog = new(sysMessage, LogLevel.Error, LogCategory.DataStore, DateTime.Now);
					logManager.LogData(userLog);
					failedMods++;
                }
				else if (sysMessage == "User account record modification successful.")
                {
					userLog = new(sysMessage, LogLevel.Info, LogCategory.DataStore, DateTime.Now);
					logManager.LogData(userLog);
					successMods++;
                }
            }
			sysMessage = "Successfully modified " + successMods + ".\n Failed to insert: " + failedMods + ".\n";
			return sysMessage;
        }
		
	}
}