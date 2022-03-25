using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Contracts;

namespace Services.Implementations
{
    public class RegistrationService : IRegistrationService
    {
        //private IUserManager _userManager;

        public RegistrationService()
        {
        }

        public bool CreateUser(string email, string dob, string pw)
        {
            bool isCreated = false;
            try
            {
                //isCreated = _userManager.CreateUser(email, dob, pw);
            }
            catch
            {
                return false;
            }
            return isCreated;
        }
    }
}
