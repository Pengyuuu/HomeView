using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers.Contracts;

namespace Services.Implementations
{
    internal class RegistrationService
    {
        //private IRegistrationManager _registrationManager;

        public RegistrationService ()
        {
            
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
