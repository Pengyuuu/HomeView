using System;

public class User
{
	string firstName;
	string lastName;
	string email;
	string password;
	DateTime dob;
	string dispName;
	DateTime regDate;

	public User(string fName, string lName, string email_address, string pw, DateTime birth, string dName)
	{
		firstName = fName;
		lastName = lName;
		email = email_address;
		password = pw;
		dispName = dName;
		dob = birth;
		regDate = DateTime.UtcNow;

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
