using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers.Contracts;
using Services.Contracts;
using Core.User;
using Managers.Implementations;


namespace Managers.Implementations
{
    public class RegistrationManager : IRegistrationManager
    {
        private readonly IUserManager _userManager;
        private readonly IRegistrationService _registrationService;
        private readonly IEmailManager _emailManager;
        private readonly IAuthenticationManager _authenticationManager;

        public RegistrationManager()
        {
            _userManager = new UserManager();
            _emailManager = new EmailManager();
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

        // creates user into reg db and sends confirmation email
        public bool CreateUser(string email, string birth, string pw)
        {

            if (ValidateFields(email, birth, pw))
            {
                string userOtp = _authenticationManager.generateOTP();
                if (userOtp != null)
                {
                    User userCreate = new User();
                    userCreate.Email = email;
                    userCreate.Dob = Convert.ToDateTime(birth);
                    userCreate.Password = pw;
                    userCreate.Token = userOtp;
                    const int CREATION_MODE = 0;
                    bool isCreatedDB = _registrationService.CreateUser(userCreate, CREATION_MODE);
                    if (isCreatedDB)
                    {
                        return _emailManager.SendConfirmationEmail(userCreate.Email, userOtp);
                    }
                }
            }
            return false;

        }
    }
}
