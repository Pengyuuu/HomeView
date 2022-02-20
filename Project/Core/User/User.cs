using System;

namespace User
{
	public class User
	{
		
		private int _userId;				// user's id number
		private string _firstName;		// user's first name
		private string _lastName;		// user's last name
		private string _userEmail;			// user's userEmail
		private string _userPassword;		// user's password
		private DateTime _userDob;			// user's date of birth
		private string _dispName;		// user's display name
		private DateTime _regDate;		// user's registration date and time
		private int _userStatus;				// user's _userStatus (enabled = 1 or disabled = 0)
		private Role _userRole;				// user's Role (admin (not system admin), or user)
		
		public int UserId
        {
			get { return _userId; }
			set { _userId = value; }
        }
		
		public string FirstName
        {
			get { return _firstName; }		
			set { _firstName = value; }
        }

		public string LastName
        {
			get { return _lastName; }
			set { _lastName = value; }
        }

		public string UserEmail
        {
			get { return _userEmail; }
			set { _userEmail = value; }
        }

		public string UserPassword
        {
			get { return _userPassword; }
			set { _userPassword = value; }
        }

		public DateTime UserDob
        {
			get { return _userDob; }
			set { _userDob = value; }
        }

		public string DispName
        {
			get { return _dispName; }
			set { _dispName = value; }
        }

		public DateTime RegDate
        {
			get { return _regDate; }
        }

		public int UserStatus
        {
			get { return _userStatus; }
			set { _userStatus = value; }
        }
		
		public Role UserRole
        {
			get { return _userRole; }
			set { _userRole = value; }
        }

		/** User Constructor
		 * Creates a new User given first name, last name, userEmail address, password, 
		 * date of birth, display name, and Role
		 * Returns: User
		 */
		public User()
        {
			this._firstName = "";
			this._lastName = "";
			this._userEmail = "";
			this._userPassword = "";
			this._dispName = "";
        }
		
		public User(string fName, string lName, string emailAddr, string userPassword, DateTime userDob, 
			string dName, int userStatus, Role userRole)
		{


			_firstName = fName;
			_lastName = lName;
			_userEmail = emailAddr;
			_userPassword = userPassword;
			_dispName = dName;
			_userDob = userDob;
			_regDate = DateTime.UtcNow;
			_userStatus = userStatus;		// all users default to enabled account
			_userRole = userRole;

		}

		public User(string csvLine)
		{
			string[] delimiter = csvLine.Split('|');
			_firstName = delimiter[0];
			_lastName = delimiter[1];
			_userEmail = delimiter[2];
			_userPassword = delimiter[3];
			_userDob = Convert.ToDateTime(delimiter[4]);
			_dispName = delimiter[5];
			_regDate = DateTime.UtcNow;
			_userStatus = Convert.ToInt16(delimiter[6]);
			_userRole = (Role) (Convert.ToInt16(delimiter[7]));

		}

		public User(int id, string fName, string lName, string emailAddr, string userPassword, DateTime userDob, 
			string dName, DateTime reg, int userStatus, Role userRole)
		{

			_userId = id;
			_firstName = fName;
			_lastName = lName;
			_userEmail = emailAddr;
			_userPassword = userPassword;
			_userDob = userDob;
			_dispName = dName;
			_regDate = reg;
			_userStatus = userStatus;		// all users default to enabled account
			_userRole = userRole;

		}


		public User ReadUser(string csvLine)
		{
			string[] delimiter = csvLine.Split(',');
			_userId = Convert.ToInt32(delimiter[0]);
			_firstName = delimiter[1];
			_lastName = delimiter[2];
			_userEmail = delimiter[3];
			_userPassword = delimiter[4];
			_userDob = Convert.ToDateTime(delimiter[5]);
			_dispName = delimiter[6];
			_regDate = Convert.ToDateTime(delimiter[7]);
			_userStatus = (Convert.ToInt16(delimiter[8]));
			_userRole = (Role) (Convert.ToInt16(delimiter[9]));
			return new User(_userId, _firstName, _lastName, _userEmail, _userPassword, _userDob, _dispName, 
				_regDate,_userStatus,_userRole);
		}
		
		// updates user
		public void UpdateUser(string fName, string lName, string emailAddr, string userPassword, DateTime userDob, 
			string dName, int userStatus, Role userRole)
        {
			this._firstName = fName;
			this._lastName = lName;
			this._userEmail = emailAddr;
			this._userPassword = userPassword;
			this._userDob = userDob;
			this._dispName = dName;
			this._userStatus = userStatus;
			this._userRole = userRole;
        }

		// updates user to modded user
		public void UpdateUser(User u)
        {
			this._firstName = u._firstName;
			this._lastName = u._lastName;
			this._userEmail = u._userEmail;
			this._userPassword = u._userPassword;
			this._userDob = u._userDob;
			this._dispName = u._dispName;
			this._userStatus = u._userStatus;
			this._userRole = u._userRole;
        }

		public void UpdateUser(string csvLine)
        {
			string[] delimiter = csvLine.Split(',');
			this._firstName = delimiter[1];
			this._lastName = delimiter[2];
			this._userEmail = delimiter[3];
			this._userPassword = delimiter[4];
			this._userDob = Convert.ToDateTime(delimiter[6]);
			this._dispName = delimiter[5];
			this._userStatus = Convert.ToInt16(delimiter[8]);
			this._userRole = (Role) (Convert.ToInt16(delimiter[9]));
        }

		public User GetUser(string result)
        {
			User setUser = new User();
			setUser.UpdateUser(result);
			return setUser;
        }
				
		override
		public String ToString()
        {
            if (this == null)
            {
                return "User not found.";
            }
            return this._userId + ", " + this._firstName + ", "+ this._lastName + ", " + this._userEmail 
				+ ", " + this._userPassword + ", " + this._userDob + ", " + this._dispName + ", " 
				+ this._regDate + ", " + this._userStatus + ", " + this._userRole;
        }
	}
}