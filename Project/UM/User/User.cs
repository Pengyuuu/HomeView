using System;

namespace UM.User
{
	public class User
	{
		
		private static int id = 0;		// id number counter
		private int userId;				// user's id number
		private string firstName;		// user's first name
		private string lastName;		// user's last name
		private string email;			// user's email
		private string password;		// user's password
		private DateTime dob;			// user's date of birth
		private string dispName;		// user's display name
		private DateTime regDate;		// user's registration date and time
		private int status;				// user's status (enabled or disabled)
		private Role role;				// user's Role (admin (not system admin), or user)
		

		/** User Constructor
		 * Creates a new User given first name, last name, email address, password, date of birth, display name, and Role
		 * Returns: User
		 */
		public User(string fName, string lName, string email_address, string pw, DateTime birth, string dName, Role r)
		{
			id++;
			userId = id;
			firstName = fName;
			lastName = lName;
			email = email_address;
			password = pw;
			dispName = dName;
			dob = birth;
			regDate = DateTime.UtcNow;
			status = 1;
			role = r;

		}

		public User(string csvLine)
		{
			string[] delimiter = csvLine(',');
			id++;
			userId = id;
			firstName = delimiter[0];
			lastName = delimiter[1];
			email = delimiter[2];
			password = delimiter[3];
			dispName = delimiter[4];
			dob = Convert.ToDateTime(delimiter[5]);
			regDate = DateTime.UtcNow;
			status = 1;
			role = (Role) (Convert.ToInt16(delimiter[6]));

		}

		public void updateUser(int id, string fName, string lName, string email_address, string pw, DateTime birth, string dName, Role r)
        {
			this.firstName = fName;
			this.lastName = lName;
			this.email = email_address;
			this.password = pw;
			this.dob = birth;
			this.dispName = dName;
			this.role = r;
        }

		public void updateUser(string csvLine)
        {
			this.firstName = fName;
			this.lastName = lName;
			this.email = email_address;
			this.password = pw;
			this.dob = birth;
			this.dispName = dName;
			this.role = r;
        }

		public User getUser(int id)
        {

        }

		/* Gets a user's id number */
		public int getid()
        {
			return userId;
        }

		/* Gets a user's first name */
		public string getfirst()
		{
			return this.firstName;
		}

		/* Gets a user's last name */
		public string getlast()
		{
			return this.lastName;
		}

		/* Gets a user's email */
		public string getemail()
		{
			return this.email;
		}

		/* Gets a user's password */
		public string getpw()
		{
			return this.password;
		}

		/* Gets user's date of birth */
		public DateTime getdob()
		{
			return this.dob;
		}

		/* Gets a user's display name */
		public string getdisp()
		{
			return this.dispName;
		}

		/* Gets a user's registration date and time */
		public DateTime getreg()
		{
			return this.regDate;
		}

		/* Gets a usr's status (enabled or disabled) */
		public int getstatus()
        {
			return this.status;
        }
		
		/* Gets a user's role (System admin, admin, or user) */
		public Role getrole()
        {
			return this.role;
        }

	}
}