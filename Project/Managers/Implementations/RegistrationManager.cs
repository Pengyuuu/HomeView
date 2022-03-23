﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    public class RegistrationManager : IRegistrationManager
    {
        private UserManager _userManager;

        public RegistrationManager()
        {
            _userManager = new UserManager();
        }

        public bool ValidateEmail(string email)
        {
            if (email != null)
            {
                //  makes sure new user's email is valid (contains @.com)
                if (email.Contains("@") && email.Contains(".com"))
                {
                    // check if in db
                    if (_userManager.GetUser(email) == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ValidatePassword(string password)
        {
            const int MIN_PASS_LENGTH = 12;
            bool hasUpper = false;
            bool hasSpecial = false;

            if (password != null)
            {
                // not null, checks length
                if (password.Length >= MIN_PASS_LENGTH)
                {
                    foreach (char character in password)
                    {
                        if (Char.IsUpper(character))
                        {
                            hasUpper = true;
                        }
                        else if ((!Char.IsLetterOrDigit(character)) && (character != ' '))
                        {
                            hasSpecial = true;
                        }
                    }
                    return hasUpper == hasSpecial;
                }

            }
            return false;
        }

        public bool ValidateBirth(string dob)
        {
            DateTime birth = Convert.ToDateTime(dob);
            const int MINIMUM_AGE = 13;

            if (dob is not null)
            {
                DateTime presentTime = DateTime.Today;

                int age = presentTime.Year - birth.Year;
                if (age >= MINIMUM_AGE)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateFields(string email, string dob, string pw)
        {
            return ValidateEmail(email) == ValidatePassword(pw) == ValidateBirth(dob);
        }

        public bool CreateUser(string email, string dob, string pw)
        {
            bool isValid = ValidateFields(email, dob, pw);
            if (isValid)
            {
                return _userManager.CreateUser(email, dob, pw);

            }
            return false;

        }
    }
}
