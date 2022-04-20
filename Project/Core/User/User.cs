using System;
using System.Collections.Generic;
//using Features.Ratings_and_Reviews;

namespace Core.User
{
	public class User
	{
		
		private string _firstName;		// user's first name
		private string _lastName;		// user's last name
		private string _email;			// user's userEmail
		private string _password;		// user's password
		private DateTime _dob;			// user's date of birth
		private string _dispName;		// user's display name
		private DateTime _regDate;		// user's registration date and time
		private bool _status;           // user's _userStatus (enabled = 1 or disabled = 0)
		private Role _role;             // user's role (admin or user)
		private string _token;          // user's token for 2FA
		//private List<RatingAndReview> _reviews;		// user's list of reviews made
		private string _salt; // salt generated for user's password

		/**
		public List<RatingAndReview> Reviews
        {
			get { return _reviews; }
			set { _reviews = value; }
        }**/

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

		public bool Status
        {
			get { return _status; }
			set { _status = value; }
        }

		public Role Role
        {
			get { return _role; }
			set { _role = value; }
        }

		public string Token
		{
			get { return _token; }
			set { _token = value; }
		}

		
		public string Salt
		{
			get { return _salt; }
			set { _salt = value; }
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
			this._role = Role.User;
			this._dob = new DateTime();
			this._status = false;
			this._salt = "";
		}

		public User(string emailAddr, string userPassword)
		{			
			_email = emailAddr;
			_password = userPassword.GetHashCode().ToString();

		}

		public User(string fName, string lName, string emailAddr, string userPassword, DateTime userDob,
			string dName, string salt, bool userStatus = false)
		{
			_firstName = fName;
			_lastName = lName;
			_email = emailAddr;
			_password = userPassword.GetHashCode().ToString();
			_dispName = dName;
			_dob = userDob;
			_status = userStatus;
			_role = Role.User;
			_salt = salt;
		}

		public User(string fName, string lName, string emailAddr, string userPassword, DateTime userDob, 
			string dName, Role userRole, bool userStatus = false)
		{
			_firstName = fName;
			_lastName = lName;
			_email = emailAddr;
			_password = userPassword.GetHashCode().ToString();
			_dispName = dName;
			_dob = userDob;
			_status = userStatus;
			_role = userRole;

		}

		public User ReadUser(string csvLine)
		{
			string[] delimiter = csvLine.Split(',');
			_firstName = delimiter[1];
			_lastName = delimiter[2];
			_email = delimiter[3];
			_password = delimiter[4];
			_dob = Convert.ToDateTime(delimiter[5]);
			_dispName = delimiter[6];
			_regDate = Convert.ToDateTime(delimiter[7]);
			_role = (Role)(Convert.ToInt16(delimiter[7]));
			_status = bool.Parse(delimiter[8]);
			//_salt = delimiter[9];
			return new User(_firstName, _lastName, _email, _password, _dob, _dispName,_role, _status);
		}

				
		override
		public String ToString()
        {
            if (this == null)
            {
                return "User not found.";
            }
            return this._firstName + ", "+ this._lastName + ", " + this._email 
				+ ", " + this._password + ", " + this._dob + ", " + this._dispName + ", " 
				+ this._regDate + ", " + this._role + "," +  this._status;
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