using System;

namespace UM.User
{
	public class User
	{
		
		private int userId;				// user's id number
		private string firstName;		// user's first name
		private string lastName;		// user's last name
		private string email;			// user's email
		private string password;		// user's password
		private DateTime dob;			// user's date of birth
		private string dispName;		// user's display name
		private DateTime regDate;		// user's registration date and time
		private int status;				// user's status (enabled = 1 or disabled = 0)
		private Role role;				// user's Role (admin (not system admin), or user)
		

		/** User Constructor
		 * Creates a new User given first name, last name, email address, password, date of birth, display name, and Role
		 * Returns: User
		 */
		public User()
        {
			this.firstName = "";
			this.lastName = "";
			this.email = "";
			this.password = "";
			this.dispName = "";
        }
		
		public User(string fName, string lName, string email_address, string pw, DateTime birth, string dName, int s, Role r)
		{
			
			
			firstName = fName;
			lastName = lName;
			email = email_address;
			password = pw;
			dispName = dName;
			dob = birth;
			regDate = DateTime.UtcNow;
			status = s;		// all users default to enabled account
			role = r;

		}

		public User(string csvLine)
		{
			string[] delimiter = csvLine.Split('|');
			firstName = delimiter[0];
			lastName = delimiter[1];
			email = delimiter[2];
			password = delimiter[3];
			dob = Convert.ToDateTime(delimiter[4]);
			dispName = delimiter[5];
			regDate = DateTime.UtcNow;
			status = Convert.ToInt16(delimiter[6]);
			role = (Role) (Convert.ToInt16(delimiter[7]));

		}

		public User(int id, string fName, string lName, string email_address, string pw, DateTime birth, string dName, DateTime reg, int s, Role r)
		{
			
			userId = id;
			firstName = fName;
			lastName = lName;
			email = email_address;
			password = pw;
			dob = birth;
			dispName = dName;
			regDate = reg;
			status = s;		// all users default to enabled account
			role = r;

		}


		public User readUser(string csvLine)
		{
			string[] delimiter = csvLine.Split(',');
			userId = Convert.ToInt32(delimiter[0]);
			firstName = delimiter[1];
			lastName = delimiter[2];
			email = delimiter[3];
			password = delimiter[4];
			dob = Convert.ToDateTime(delimiter[5]);
			dispName = delimiter[6];
			regDate = Convert.ToDateTime(delimiter[7]);
			status = (Convert.ToInt16(delimiter[8]));
			role = (Role) (Convert.ToInt16(delimiter[9]));
			return new User(userId,firstName,lastName,email,password,dob,dispName,regDate,status,role);
		}
		
		// updates user
		public void updateUser(string fName, string lName, string email_address, string pw, DateTime birth, string dName, int s, Role r)
        {
			this.firstName = fName;
			this.lastName = lName;
			this.email = email_address;
			this.password = pw;
			this.dob = birth;
			this.dispName = dName;
			this.status = s;
			this.role = r;
        }

		// updates user to modded user
		public void updateUser(User u)
        {
			this.firstName = u.firstName;
			this.lastName = u.lastName;
			this.email = u.email;
			this.password = u.password;
			this.dob = u.dob;
			this.dispName = u.dispName;
			this.status = u.status;
			this.role = u.role;
        }

		public void updateUser(string csvLine)
        {
			string[] delimiter = csvLine.Split(',');
			this.firstName = delimiter[1];
			this.lastName = delimiter[2];
			this.email = delimiter[3];
			this.password = delimiter[4];
			this.dob = Convert.ToDateTime(delimiter[6]);
			this.dispName = delimiter[5];
			this.status = Convert.ToInt16(delimiter[8]);
			this.role = (Role) (Convert.ToInt16(delimiter[9]));
        }


		public User getUser(string result)
        {
			User setUser = new User();
			setUser.updateUser(result);
			return setUser;
        }

		/* Gets a user's first name */
		public int getid()
		{
			return this.userId;
		}

		/* Gets a user's first name */
		public string getfirst()
		{
			return this.firstName;
		}

		/* sets a user's first name */
		public void setfirst(User n)
		{
			this.firstName = n.firstName;
		}

		/* Gets a user's last name */
		public string getlast()
		{
			return this.lastName;
		}

		/* sets a user's last name */
		public void setLast(User n)
		{
			this.lastName = n.lastName;
		}

		/* Gets a user's email */
		public string getemail()
		{
			return this.email;
		}

		/* sets a user's email */
		public void setEmail(User n)
		{
			this.email = n.email;
		}

		/* Gets a user's password */
		public string getpw()
		{
			return this.password;
		}

		/* sets a user's password */
		public void setpw(User n)
		{
			this.password = n.password;
		}

		/* Gets user's date of birth */
		public DateTime getdob()
		{
			return this.dob;
		}

		/* sets a user's dob */
		public void setbirth(User n)
		{
			this.dob = n.dob;
		}

		/* Gets a user's display name */
		public string getdisp()
		{
			return this.dispName;
		}

		/* sets a user's display name */
		public void setdisp(User n)
		{
			this.dispName = n.dispName;
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

		/* sets a user's status */
		public void setstatus(User n)
		{
			this.status = n.status;
		}
		
		/* Gets a user's role (System admin, admin, or user) */
		public Role getrole()
        {
			return this.role;
        }

		/* sets a user's first name */
		public void setRole(User n)
		{
			this.role = n.role;
		}

		
		public String toString()
        {
            if (this == null)
            {
                return "User not found.";
            }

            return this.userId + ", " + this.firstName+", "+ this.lastName + ", " + this.email + ", " + this.password + ", " + this.dob + ", " + this.dispName + ", " + this.regDate + ", " + this.status + ", " + this.role;
        }

	}
}