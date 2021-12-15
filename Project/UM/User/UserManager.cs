using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Logging.Logging;


/* User Authentication and Authorization Manager */
namespace UM.User {
	public class UserManager
	{
		private String sysadmin = "TeamUnite";
		private String sysadminpw = "Testing";
		private UMService umService;
		private Boolean verified = false;


		public UserManager(string adminInput, string pw)
		{
			umService = new UMService(this);
			verified = verifyAdmin(adminInput, pw);
		}

		/* Verifies if actor is system administrator 
		 * Returns: true if matches, false if doesn't match
		 */
		public Boolean verifyAdmin(string adminInput, string pw)
		{
			Log checkAdminlog = new ("verifying admin", LogLevel.Info, LogCategory.View, DateTime.Now);
			LoggingManager logm = new LoggingManager();
			logm.logData(checkAdminlog);

			// checks if input matches system admin info
			Boolean check1 = adminInput == this.sysadmin;	
			Boolean check2 = pw == this.sysadminpw;
			return check1 == check2;

		}

		/* Ensures that New user has entered correct fields 
		 *	Checks for valid email address, valid password */
		public Boolean checkNewUser(User u)
		{
			Log userlog = new("checking user in database", LogLevel.Info, LogCategory.Data, DateTime.Now);
			LoggingManager logm = new LoggingManager();
			logm.logData(userlog);

			//  makes sure new user's email is valid (contains @.com)
			string email = u.getemail();
			Boolean emailCheck = (email.Contains("@") == email.Contains(".com"));

			// makes sure new user's password is valid (contains minimum of 12 characters, at least 1 capital letter, at least 1 non-alphanumeric character
			string pw = u.getpw();
			int pwMinLength = 12;
			Boolean containsUpper = false;
			Boolean containsNonAlpha = false;
			Boolean lengthCheck = false;

			// ensures password meets length requirement
			if (pw.Length >= pwMinLength)
			{
				lengthCheck = true;
			}

			// ensures pasword meets capital and non-alphanumeric requirement
			for (int i = 0; i < pw.Length; i++)
			{
				if (Char.IsUpper(pw[i]))
				{
					containsUpper = true;
				}

				if (!Char.IsLetterOrDigit(pw[i]))
				{
					containsNonAlpha = true;
				}
			}

			return (emailCheck == containsUpper == containsNonAlpha == lengthCheck);

		}

		// Gets user
		
		public String UserManagerGetUser(int id)
        {
			Log userlog = new();
			LoggingManager logm = new LoggingManager();
			if (!this.verified)
			{
				userlog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logm.logData(userlog);

				return "Unauthorized access";
			}

			if (!umService.UMServiceCheckUser(id))
            {
				userlog = new("User does not exist", LogLevel.Error, LogCategory.View, DateTime.Now);
				logm.logData(userlog);

				return "User does not exist";
            }

			userlog = new("User found.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logm.logData(userlog);

			User m = this.umService.UMServiceGetUser(id);

			return m.toString();

        }

		public String UserManagerGetAllUsers()
		{
			Log userlog = new();
			LoggingManager logm = new LoggingManager();

			if (!this.verified)
			{
				userlog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logm.logData(userlog);
				return "Unauthorized access";
			}

			userlog = new("Fetching all users.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logm.logData(userlog);
			return this.umService.UMServiceGetAllUsers();

		}

		public String UserManagerExportAllUsers(string filepath)
		{
			Log userlog = new();
			LoggingManager logm = new LoggingManager();
			if (!this.verified)
			{
				userlog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logm.logData(userlog);
				return "Unauthorized access";
			}

			if (!this.umService.UMServiceExportAllUsers(filepath)) {
				userlog = new("Unable to export all users to file.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logm.logData(userlog);
				return "Unable to export all users.";
            }

			userlog = new("Exported all users to .csv", LogLevel.Info, LogCategory.View, DateTime.Now);
			logm.logData(userlog);
			return "User data successfully exported to .csv file in: " + filepath;

		}

		/* Creates a new user record in system 
		 * Returns success or unsuccessful message
		 */
		public String UserManagerCreateUser(User u)
		{
			Log userlog = new();
			LoggingManager logm = new LoggingManager();
			// if user is not admin, returns unauthorized access
			if (!this.verified)
			{
				userlog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logm.logData(userlog);
				return "Unauthorized access.";
			}

			Boolean newuserCheck = checkNewUser(u);			

			//  if new user has incorrect inputs
			if (!newuserCheck)
			{
				userlog = new("Invalid inputs for new user", LogLevel.Error, LogCategory.Data, DateTime.Now);
				logm.logData(userlog);
				return "Invalid inputs for new user.";
			}

			userlog = new("Inserting user", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logm.logData(userlog);
			// Calls service layer to create the new user
			string m = this.umService.UMServiceCreateUser(u) == true ? "User account record creation successful." : "Account creation unsuccessful. Account already exists in system. ";
			if (!this.umService.UMServiceCreateUser(u))
            {
				userlog = new("Failed to create user", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
				logm.logData(userlog);
			}
			else
            {
				userlog = new("Inserted user.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
				logm.logData(userlog);
			}

			return m;
		}

		/* Modifies a user record in the system 
		 * 1 = Update information
		 * 2 = Delete account
		 * 3 = Disable
		 * 4 = Enable
		 * Returns a success or unsuccessful message
		 */
		public String UserManagerModifyUser(int id, int mode, User userMod)
		{
			Log userlog = new();
			LoggingManager logm = new LoggingManager();
			// if user is not admin, returns unauthorized access
			if (!this.verified)
			{
				userlog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logm.logData(userlog);
				return "Unauthorized access.";
			}

			if (!this.umService.UMServiceCheckUser(id))
            {
				userlog = new("User does not exist", LogLevel.Error, LogCategory.View, DateTime.Now);
				logm.logData(userlog);
				return "User does not exist.";
            }

			userlog = new("Modifying user", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			logm.logData(userlog);
			// calls service layer to modify user
			string m = this.umService.UMServiceModifyUser(id, mode, userMod) == true ? "User account modification successful." : "Account modification unsuccessful.";

			if (!this.umService.UMServiceModifyUser(id, mode, userMod))
			{
				userlog = new("Failed to modify user", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
				logm.logData(userlog);
			}
			else
			{
				userlog = new("Account modification unsuccessful.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
				logm.logData(userlog);
			}

			return m;
		}

		
		public String BulkOperationCreateUsers(string file)
        {
			Log userlog = new();
			LoggingManager logm = new LoggingManager();
			// if user is not admin, returns unauthorized access
			if (!this.verified)
			{
				userlog = new( "Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logm.logData(userlog);
				return "Unauthorized access.";
			}
			userlog = new("Starting bulk operation to create users", LogLevel.Info, LogCategory.Data, DateTime.Now);
			logm.logData(userlog);

			List <User> users = File.ReadAllLines(file).Skip(1).Select(u => new User(u)).ToList();
			
			string m = "";
			int insertedUsers = 0;
			int failedInsert = 0;

			foreach(User u in users)
            {
				m = UserManagerCreateUser(u);
				
				if (m == "Invalid inputs for new user.")
                {
					userlog = new("Invalid inputs for new user", LogLevel.Error, LogCategory.Data, DateTime.Now);
					logm.logData(userlog);
					return ("Invalid inputs for new user " + u.getemail());
                }
				else if (m == "Account creation unsuccessful. Account already exists in system.")
                {
					userlog = new("Account for new user already exists", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
					logm.logData(userlog);
					failedInsert++;
                }
				else if (m == "User account record creation successful.")
                {
					userlog = new("User account creation successful", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
					logm.logData(userlog);
					insertedUsers++;
                }
            }
			m = "Successfully inserted " + insertedUsers + ".\n Failed to insert: " + failedInsert + ".\n";
			return m;
        }
		
		public String BulkOperationModifyUsers(string file)
        {
			Log userlog = new();
			LoggingManager logm = new LoggingManager();
			// if user is not admin, returns unauthorized access
			if (!this.verified)
			{
				userlog = new("Unauthorized admin access.", LogLevel.Error, LogCategory.View, DateTime.Now);
				logm.logData(userlog);
				return "Unauthorized access.";
			}

			List <String> mods = File.ReadAllLines(file).Skip(1).ToList();
			
			string m = "";
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

				userMod.updateUser(mfirstName, mlastName, memail, mpassword, mdob, mdispName, mstatus, mr);


				m = UserManagerModifyUser(id, mode, userMod);

				if (m == "Invalid inputs for new user.")
                {
					userlog = new("Invalid inputs for new user. ", LogLevel.Error, LogCategory.Data, DateTime.Now);
					logm.logData(userlog);
					return ("Invalid inputs for new user id: " + id);
                }
				else if (m == "Account modification unsuccessful.")
                {
					userlog = new(m, LogLevel.Error, LogCategory.DataStore, DateTime.Now);
					logm.logData(userlog);
					failedMods++;
                }
				else if (m == "User account record modification successful.")
                {
					userlog = new(m, LogLevel.Info, LogCategory.DataStore, DateTime.Now);
					logm.logData(userlog);
					successMods++;
                }
            }
			m = "Successfully modified " + successMods + ".\n Failed to insert: " + failedMods + ".\n";
			return m;
        }
		
	}
}