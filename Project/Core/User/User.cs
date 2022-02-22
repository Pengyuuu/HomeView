using System;

namespace Core.User
{
	public class User
	{
		
		private int _Id;				// user's id number
		private string _firstName;		// user's first name
		private string _lastName;		// user's last name
		private string _email;			// user's userEmail
		private string _password;		// user's password
		private DateTime _dob;			// user's date of birth
		private string _dispName;		// user's display name
		private DateTime _regDate;		// user's registration date and time
		private int _status;			// user's _userStatus (enabled = 1 or disabled = 0)
		private Role _role;				// user's Role (admin (not system admin), or user)
		
		public int Id
        {
			get { return _Id; }
			set { _Id = value; }
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

		public string Email
        {
			get { return _email; }
			set { _email = value; }
        }

		public string Password
        {
			get { return _password; }
			set { _password = value; }
        }

		public DateTime Dob
        {
			get { return _dob; }
			set { _dob = value; }
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

		public int Status
        {
			get { return _status; }
			set { _status = value; }
        }
		
		public Role Role
        {
			get { return _role; }
			set { _role = value; }
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
			this._email = "";
			this._password = "";
			this._dispName = "";
        }
		
		public User(string fName, string lName, string emailAddr, string userPassword, DateTime userDob, 
			string dName, int userStatus, Role userRole)
		{
			_firstName = fName;
			_lastName = lName;
			_email = emailAddr;
			_password = userPassword;
			_dispName = dName;
			_dob = userDob;
			_regDate = DateTime.UtcNow;
			_status = userStatus;		// all users default to enabled account
			_role = userRole;

		}

		public User(string csvLine)
		{
			string[] delimiter = csvLine.Split('|');
			_firstName = delimiter[0];
			_lastName = delimiter[1];
			_email = delimiter[2];
			_password = delimiter[3];
			_dob = Convert.ToDateTime(delimiter[4]);
			_dispName = delimiter[5];
			_regDate = DateTime.UtcNow;
			_status = Convert.ToInt16(delimiter[6]);
			_role = (Role) (Convert.ToInt16(delimiter[7]));

		}


		public User ReadUser(string csvLine)
		{
			string[] delimiter = csvLine.Split(',');
			_Id = Convert.ToInt32(delimiter[0]);
			_firstName = delimiter[1];
			_lastName = delimiter[2];
			_email = delimiter[3];
			_password = delimiter[4];
			_dob = Convert.ToDateTime(delimiter[5]);
			_dispName = delimiter[6];
			_regDate = Convert.ToDateTime(delimiter[7]);
			_status = (Convert.ToInt16(delimiter[8]));
			_role = (Role) (Convert.ToInt16(delimiter[9]));
			return new User(_firstName, _lastName, _email, _password, _dob, _dispName,_status,_role);
		}

				
		override
		public String ToString()
        {
            if (this == null)
            {
                return "User not found.";
            }
            return this._Id + ", " + this._firstName + ", "+ this._lastName + ", " + this._email 
				+ ", " + this._password + ", " + this._dob + ", " + this._dispName + ", " 
				+ this._regDate + ", " + this._status + ", " + this._role;
        }

		public bool Equals(User u)
        {
			if (this.Email == u.Email)
            {
				return true;
            }
			return false;
        }
	}
}