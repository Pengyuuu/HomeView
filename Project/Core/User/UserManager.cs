using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data;

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

		public Task CreateUser(User user)
		{
			return _userDAO.CreateUser(user);
		}

		// Gets user
		public User GetUser(string email)
        {
			User u =(User)_userDAO.ReadUser(email).Result;	
			Log userLog = new("User found.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
			_loggingManager.LogData(userLog);
			return u;
        }

		public List<User> GetAllUsers()
		{
			try
            {
				IEnumerable<User> u = _userDAO.ReadAllUsers().Result;
				Log userLog = new("All users retrieved.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
				_loggingManager.LogData(userLog);
				return u.ToList();
			}
			catch (Exception ex)
            {
				Log userLog = new("GetAllUsers failed " + ex.Message, LogLevel.Info, LogCategory.DataStore, DateTime.Now);
				_loggingManager.LogData(userLog);
			}
			return new List<User>();
		}

		public bool DeleteUser(string email)
        {
			User user = GetUser(email);
			if (user is not null)
            {
				_userDAO.DeleteUser(email);
				Log userLogTrue = new("User: " + user.UserEmail + " - successfully deleted.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
				_loggingManager.LogData(userLogTrue);
				return true;
            }
			else
            {
				Log userLogFalse = new("User: " + email + " - unsuccessful delete user.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
				_loggingManager.LogData(userLogFalse);
				return false;
			}
        }

		public User ModifyUser(User user)
        {
			User curUser = GetUser(user.UserEmail);
			if (user is not null)
			{
				Task t = _userDAO.UpdateUser(user);
				Log userLog = new("User: " + user.UserEmail + " updated.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
				_loggingManager.LogData(userLog);
				return GetUser(user.UserEmail);
			}
			else
			{
				CreateUser(user);
				Log userLog = new("User: " + user.UserEmail + " could not be modified because it did not exist. Creating user.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
				_loggingManager.LogData(userLog);
				return user;
			}

		}

		// Write to CSV File
		public String ExportAllUsers()
		{
			var userList = _userDAO.ReadAllUsers();
			string filePath = Path.GetFullPath("@\\..\\..\\..\\..\\..\\..\\Project\\Data\\ExportedUserData.csv");
			Log userLog;

			if (userList == null) {
				userLog = new("Unable to export all users to file.", LogLevel.Error, LogCategory.View, DateTime.Now);
				_loggingManager.LogData(userLog);
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
			_loggingManager.LogData(userLog);
			return "User data successfully exported to .csv file";
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