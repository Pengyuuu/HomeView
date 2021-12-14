using System;

/* User Authentication and Authorization Manager */
namespace UM.User {
	public class UserManager
	{
		private String sysadmin = "TeamUnite";
		private String sysadminpw = "Testing";
		private static UMService umService;

		public UserManager()
		{
			umService = new UMService();
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

		/* Creates a new user record in system 
		 * Returns success or unsuccessful message
		 */
		public String UserManagerCreateUser(string adminInput, string pw, User u)
		{
			// verifies user is system admin
			Boolean adminCheck = verifyAdmin(adminInput, pw);
			Boolean newuserCheck = checkNewUser(u);

			// if user is not admin, returns unauthorized access
			if (!adminCheck)
			{
				return "Unauthorized access.";
			}

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
		public String UserManagerModifyUser(string adminInput, string pw, User u, int mode, User userMod)
		{
			// verifies user is system admin
			Boolean adminCheck = verifyAdmin(adminInput, pw);

			// if user is not admin, returns unauthorized access
			if (!adminCheck)
			{
				return "Unauthorized access.";
			}

			// calls service layer to modify user
			string m = this.umService.UMServiceModifyUser(u, mode, userMod) == true ? "User account record creation successful." : "Account creation unsuccessful. Account already exists in system. ";
			return m;
		}

		public String BulkOperationCreateUsers()
        {
			return "";
        }

		public String BulkOperationModifyUsers()
        {
			return "";
        }
	}
}