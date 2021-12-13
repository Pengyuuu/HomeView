using System;
//using UserManagement.User;


/* User Authentication and Authorization Manager */
namespace Unite.HomeView.User {
	class UserManager
	{
		private String admin = "TeamUnite";
		private String adminpw = "Testing";
		private UMService = umservice;

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
			stirng pw = Console.ReadLine();
			Boolean check1 = adminUsername == this.admin ? true : false;
			Boolean check2 = adminpw == this.adminpw ? true : false;
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
			int fields = 3;     // must have valid at least 12 char, at least 1 upper char, at least 1 non-alphanum char
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


		public String UserManagerCreateUser(User u)
		{
			Boolean adminCheck = verifyAdmin();
			Boolean newuserCheck = checkNewUser();

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
		 * 2 = Update information
		 * 3 = Delete account
		 * 4 = Disable
		 * 5 = Enable
		 */
		public String UserManagerModifyUser(User u, int mode)
		{
			Boolean adminCheck = verifyAdmin();

			if (!adminCheck)
			{
				return "Unauthorized access.";
			}



			string m = this.umService.UMServiceCreateUser(u) == true ? "User account record creation successful." : "Account creation unsuccessful. Account already exists in system. ";
			return m;
		}
	}
}