﻿using System;

//namespace UserManagement
public class User
{
	private string firstName;
	private string lastName;
	private string email;
	private string password;
	private DateTime dob;
	private string dispName;
	private DateTime regDate;

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
