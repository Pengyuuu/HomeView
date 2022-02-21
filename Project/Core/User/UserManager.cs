using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Logging;


/* User Authentication and Authorization Manager */
namespace Core.User
{
	public class UserManager
	{
		private readonly String SYS_ADMIN = "TeamUnite";
		private readonly String SYS_PASS = "Testing";
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
			LoggingManager logManager = new();
			logManager.LogData(adminLog);

			// checks if input matches system admin info
			Boolean isAdminUser = adminInput == this.SYS_ADMIN;	
			Boolean isPass = passInput == this.SYS_PASS;
			return isAdminUser == isPass;
		}

		/* Ensures that New user has entered correct fields 
		 *	Checks for valid userEmail address, valid password */
		public Boolean IsValidUser(User u)
		{
			Log userLog = new("checking user in database", LogLevel.Info, LogCategory.Data, DateTime.Now);
			LoggingManager logManager = new();
			logManager.LogData(userLog);

			//  makes sure new user's userEmail is valid (contains @.com)
			string userEmail = u.UserEmail;
			Boolean isValidEmail = (userEmail.Contains("@") == userEmail.Contains(".com"));

			// makes sure new user's password is valid (contains minimum of 12 characters, at least 1 capital letter, at least 1 non-alphanumeric character
			string userPass = u.UserPassword;
			int PASS_MIN_LENGTH = 12;
			Boolean containsUpper = false;
			Boolean containsNonAlpha = false;
			Boolean hasLength = false;

			// ensures password meets length requirement
			if (userPass.Length >= PASS_MIN_LENGTH)
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
		public String GetUser(User user)
        {
			Log userLog = new();
			LoggingManager logManager = new();
			if (!this._isVerified)
			{
				userLog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);

				return "Unauthorized access";
			}

			if (!_umService.IsUser(user))
            {
				userLog = new("User does not exist", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);

				return "User does not exist";
            }

			userLog = new("User found.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);

			var fetchedUser = this._umService.GetUser(user);

			return fetchedUser.ToString();

        }

		public String GetAllUsers()
		{
			Log userLog = new();
			LoggingManager logManager = new();

			if (!this._isVerified)
			{
				userLog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "Unauthorized access";
			}

			userLog = new("Fetching all users.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);

			var result = this._umService.GetAllUsers();			
			return result.ToString();

		}

		// Write to CSV File
		public String ExportAllUsers()
		{
			Log userLog = new();
			LoggingManager logManager = new();
			if (!this._isVerified)
			{
				userLog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "Unauthorized access";
			}

			var userList = this._umService.GetAllUsers();
			string filePath = Path.GetFullPath("@\\..\\..\\..\\..\\..\\..\\Project\\Data\\ExportedUserData.csv");

			if (userList == null) {
				userLog = new("Unable to export all users to file.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "Unable to export all users.";
            }			

			try
			{
				File.WriteAllText(filePath, userList.ToString());
			}
			catch (Exception e)
			{
				return "Unable to export all users.";
			}

			userLog = new("Exported all users to .csv", LogLevel.Info, LogCategory.View, DateTime.Now);
			logManager.LogData(userLog);
			return "User data successfully exported to .csv file";
		}

		public String CreateUser(User userMod)
		{
			Log userLog = new();
			LoggingManager logManager = new();
			// if user is not admin, returns unauthorized access
			if (!this._isVerified)
			{
				userLog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "Unauthorized access.";
			}

			if (this._umService.IsUser(userMod))
			{
				userLog = new("User already exists", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "User already exists";
			}

			userLog = new("Creating user", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);
			// calls service layer to modify user
			string sysMessage = this._umService.HasCreateUser(userMod) == true ? "User account creation successful." : "Account creation unsuccessful.";
			userLog = new(sysMessage, LogLevel.Error, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);

			return sysMessage;
		}

		/* Modifies a user record in the system 
		 * Returns a success or unsuccessful message
		 */
		public String ModifyUser(User userMod)
		{
			Log userLog = new();
			LoggingManager logManager = new();
			// if user is not admin, returns unauthorized access
			if (!this._isVerified)
			{
				userLog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "Unauthorized access.";
			}

			if (!this._umService.IsUser(userMod))
            {
				userLog = new("User does not exist", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "User does not exist.";
            }

			userLog = new("Modifying user", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);
			// calls service layer to modify user
			string sysMessage = this._umService.HasModifyUser(userMod) == true ? "User account modification successful." : "Account modification unsuccessful.";
			userLog = new(sysMessage, LogLevel.Error, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);

			return sysMessage;
		}

		public String DeleteUser(User userMod)
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

			if (!this._umService.IsUser(userMod))
			{
				userLog = new("User does not exist", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "User does not exist.";
			}

			userLog = new("Modifying user", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);
			// calls service layer to modify user
			string sysMessage = this._umService.HasDeleteUser(userMod) == true ? "User account deletion successful." : "Account deletion unsuccessful.";
			userLog = new(sysMessage, LogLevel.Error, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);

			return sysMessage;
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
				string[] delimiter = csvLine.Split('|');
				User userMod = new User();
				string mfirstName = delimiter[0];
				string mlastName = delimiter[1];
				string memail = delimiter[2];
				string mpassword = delimiter[3];
				DateTime mdob = Convert.ToDateTime(delimiter[4]);
				string mdispName = delimiter[5];
				int mstatus = Convert.ToInt16(delimiter[6]);
				Role mr = (Role) (Convert.ToInt16(delimiter[7]));

				userMod.UpdateUser(mfirstName, mlastName, memail, mpassword, mdob, mdispName, mstatus, mr);

				// Makes sure valid parameters
				if (IsValidUser(userMod))
				{
					// Creating a new user if not in database
					if (!this._umService.IsUser(userMod))
					{
						userMod = new User(mfirstName, mlastName, memail, mpassword, mdob, mdispName, mstatus, mr);
						sysMessage = CreateUser(userMod);
						if (sysMessage == "User account creation successful.")
						{
							successMods++;
						}
						else
						{
							failedMods++;
						}
					}
					// Modifying or Deleting User
					else
					{
						// checks user in DB, if exact same fields then delete occurs
						var checkUserDB = this._umService.GetUser(userMod);
						if (checkUserDB.ToString() == userMod.ToString())
						{
							sysMessage = DeleteUser(userMod);
							if (sysMessage == "User account deletion successful.")
							{
								successMods++;
							}
							else
							{
								failedMods++;
							}
						}
						else
						{
							// User's fields were modified
							sysMessage = ModifyUser(userMod);
							if (sysMessage == "User account modification successful.")
							{
								successMods++;
							}
							else
							{
								failedMods++;
							}
						}
					}
				}
				else
                {
					sysMessage = "Invalid inputs for user id: " + memail;				
					failedMods++;
				}
				userLog = new(sysMessage, LogLevel.Info, LogCategory.DataStore, DateTime.Now);
				logManager.LogData(userLog);								
            }
			sysMessage = "Successfully modified " + successMods + ".\n Failed to insert: " + failedMods + ".\n";
			return sysMessage;
        }		
	}
}