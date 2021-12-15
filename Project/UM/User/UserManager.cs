﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
			// checks if input matches system admin info
			Boolean check1 = adminInput == this.sysadmin;	
			Boolean check2 = pw == this.sysadminpw;
			return check1 == check2;

		}

		/* Ensures that New user has entered correct fields 
		 *	Checks for valid email address, valid password */
		public Boolean checkNewUser(User u)
		{
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
			if (!this.verified)
			{
				return "Unauthorized access";
			}

			if (!umService.UMServiceCheckUser(id))
            {
				return "User does not exist";
            }

			User m = this.umService.UMServiceGetUser(id);

			return m.toString();

        }

		public String UserManagerGetAllUsers()
		{
			if (!this.verified)
			{
				return "Unauthorized access";
			}

			return this.umService.UMServiceGetAllUsers();

		}

		public String UserManagerExportAllUsers(string filepath)
		{
			if (!this.verified)
			{
				return "Unauthorized access";
			}

			if (!this.umService.UMServiceExportAllUsers(filepath)) {
				return "Unable to export all users.";
            }

			return "User data successfully exported to .csv file in: " + filepath;

		}

		/* Creates a new user record in system 
		 * Returns success or unsuccessful message
		 */
		public String UserManagerCreateUser(User u)
		{
			// if user is not admin, returns unauthorized access
			if (!this.verified)
			{
				return "Unauthorized access.";
			}

			Boolean newuserCheck = checkNewUser(u);			

			//  if new user has incorrect inputs
			if (!newuserCheck)
			{
				return "Invalid inputs for new user.";
			}

			// Calls service layer to create the new user
			string m = this.umService.UMServiceCreateUser(u) == true ? "User account record creation successful." : "Account creation unsuccessful. Account already exists in system. ";
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
			// if user is not admin, returns unauthorized access
			if (!this.verified)
			{
				return "Unauthorized access.";
			}

			if (!this.umService.UMServiceCheckUser(id))
            {
				return "User does not exist.";
            }
			
			// calls service layer to modify user
			string m = this.umService.UMServiceModifyUser(id, mode, userMod) == true ? "User account modification successful." : "Account modification unsuccessful.";
			return m;
		}

		
		public String BulkOperationCreateUsers(string file)
        {
			// if user is not admin, returns unauthorized access
			if (!this.verified)
			{
				return "Unauthorized access.";
			}

			List <User> users = File.ReadAllLines(file).Skip(1).Select(u => new User(u)).ToList();
			
			string m = "";
			int insertedUsers = 0;
			int failedInsert = 0;

			foreach(User u in users)
            {
				m = UserManagerCreateUser(u);
				if (m == "Unauthorized access.")
                {
					return "Unauthorized access.";
                }
				else if (m == "Invalid inputs for new user.")
                {
					return ("Invalid inputs for new user email: " + u.getemail());
                }
				else if (m == "Account creation unsuccessful. Account already exists in system.")
                {
					failedInsert++;
                }
				else if (m == "User account record creation successful.")
                {
					insertedUsers++;
                }
            }
			m = "Successfully inserted " + insertedUsers + ".\n Failed to insert: " + failedInsert + ".\n";
			return m;
        }
		
		public String BulkOperationModifyUsers(string file)
        {

			// if user is not admin, returns unauthorized access
			if (!this.verified)
			{
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

				if (m == "Unauthorized access.")
                {
					return "Unauthorized access.";
                }
				else if (m == "Invalid inputs for new user.")
                {
					return ("Invalid inputs for new user id: " + id);
                }
				else if (m == "Account creation unsuccessful. Account already exists in system.")
                {
					failedMods++;
                }
				else if (m == "User account record creation successful.")
                {
					successMods++;
                }
            }
			m = "Successfully modified " + successMods + ".\n Failed to insert: " + failedMods + ".\n";
			return m;
        }
		
	}
}