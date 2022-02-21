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
		private LoggingManager _loggingManager;
		private UserDAO _userDAO;

		public UserManager(string adminInput, string passInput)
		{
			_loggingManager = new LoggingManager();
			_userDAO = new UserDAO(new Data.SqlDataAccess());
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
		public User GetUser(string email)
        {
			User u =(User)_userDAO.ReadUser(email).Result.First();	
			Log userLog = new("User found.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			_loggingManager.LogData(userLog);
			return u;
        }

		public String GetAllUsers()
		{
			Log userLog = new();
			LoggingManager logManager = new();

			userLog = new("Fetching all users.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);

			var result = this._userDAO.ReadUser();			
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

			var userList = this._userDAO.ReadUser();
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

			if (this._userDAO.ReadUser(userMod.UserEmail) is null);
			{
				userLog = new("User already exists", LogLevel.Error, LogCategory.View, DateTime.Now);
				logManager.LogData(userLog);
				return "User already exists";
			}

			userLog = new("Creating user", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);
			// calls service layer to modify user

			return "not implemented";
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

			userLog = new("Modifying user", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logManager.LogData(userLog);
			// calls service layer to modify user

			return "not impl";
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

			return "na";
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
											
            }
			sysMessage = "Successfully modified " + successMods + ".\n Failed to insert: " + failedMods + ".\n";
			return sysMessage;
        }		
	}
}