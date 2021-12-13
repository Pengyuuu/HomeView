using System;

namespace Unite.HomeView.User
{
	public class User
	{
		private static int id = 0;
		private int userId;
		private string firstName;
		private string lastName;
		private string email;
		private string password;
		private DateTime dob;
		private string dispName;
		private DateTime regDate;

		public User(string fName, string lName, string email_address, string pw, DateTime birth, string dName)
		{
			userId++;
			userId = id;
			firstName = fName;
			lastName = lName;
			email = email_address;
			password = pw;
			dispName = dName;
			dob = birth;
			regDate = DateTime.UtcNow;

		}

		public int getid()
        {
			return userId;
        }

		public string getfirst()
		{
			return this.firstName;
		}

		public string getlast()
		{
			return this.lastName;
		}

		public string getemail()
		{
			return this.email;
		}

		public string getpw()
		{
			return this.password;
		}

		public DateTime getdob()
		{
			return this.dob;
		}

		public string getdisp()
		{
			return this.dispName;
		}

		public DateTime getreg()
		{
			return this.regDate;
		}
	}
}