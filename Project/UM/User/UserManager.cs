using System;

/* User Authentication and Authorization Manager */
namespace UM.User {
	public class UserManager
	{
		//private String admin = "TeamUnite";
		//private String adminpw = "Testing";
		private UMService umService;

		public UserManager()
		{
			umService = new UMService();
		}

		/* Verifies if actor is system administrator */
		public Boolean verifyAdmin(string adminInput, string pw)
		{
			
			Boolean check1 = adminInput == this.admin;
			Boolean check2 = pw == this.adminpw;
			return check1 == check2;

		}

		/* Ensures that New user has entered correct fields 
		 *	Checks for valid email address, valid password, valid username */
		public Boolean checkNewUser(User u)
		{
			string email = u.getemail();
			Boolean emailCheck = (email.Contains("@") == email.Contains(".com"));

			string pw = u.getpw();
			int pwMinLength = 12;
			Boolean containsUpper = false;
			Boolean containsNonAlpha = false;
			Boolean lengthCheck = false;

			if (pw.Length >= pwMinLength)
			{
				lengthCheck = true;
			}

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

		/* Creates a new user record in system */
		public String UserManagerCreateUser(string adminInput, string pw, User u)
		{
			Boolean adminCheck = verifyAdmin(adminInput, pw);
			Boolean newuserCheck = checkNewUser(u);

			if (!adminCheck)
			{
				return "Unauthorized access.";
			}
			if (!newuserCheck)
			{
				return "Invalid inputs for new user.";
			}

			string m = this.umService.UMServiceCreateUser(u) == true ? "User account record creation successful." : "Account creation unsuccessful. Account already exists in system. ";
			return m;
		}

		/* Modifies a user record in the system 
		 * 1 = Update information
		 * 2 = Delete account
		 * 3 = Disable
		 * 4 = Enable
		 */
		public String UserManagerModifyUser(string adminInput, string pw, User u, int mode, User userMod)
		{
			Boolean adminCheck = verifyAdmin(adminInput, pw);

			if (!adminCheck)
			{
				return "Unauthorized access.";
			}

			string m = this.umService.UMServiceModifyUser(u, mode, userMod) == true ? "User account record creation successful." : "Account creation unsuccessful. Account already exists in system. ";
			return m;
		}
	}
}