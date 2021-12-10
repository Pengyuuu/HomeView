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
}
