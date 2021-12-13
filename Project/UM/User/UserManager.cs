using System;

/* User Authentication and Authorization Manager */
namespace Unite.HomeView.User {
	public class UserManager
	{
		private String admin = "TeamUnite";
		private String adminpw = "Testing";
		private UMService umService;

		public UserManager()
		{
			umService = new UMService();
		}

		/* Verifies if actor is system administrator */
		public Boolean verifyAdmin()
		{
			Console.WriteLine("Enter username:");
			string adminUsername = Console.ReadLine();
			Console.WriteLine("Enter password:");
			string pw = Console.ReadLine();
			Boolean check1 = adminUsername == this.admin;
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
		public String UserManagerCreateUser(User u)
		{
			Boolean adminCheck = verifyAdmin();
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
		public String UserManagerModifyUser(User u, int mode)
		{
			Boolean adminCheck = verifyAdmin();

			if (!adminCheck)
			{
				return "Unauthorized access.";
			}




			string m = this.umService.UMServiceModifyUser(u, mode) == true ? "User account record creation successful." : "Account creation unsuccessful. Account already exists in system. ";
			return m;
		}
	}
}