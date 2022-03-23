using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    // mechanism for identifying a valid user of the system (validation for logging in a user)
    // scope: any user attempting to use the system
    internal class AuthenticationManager
    {
        private UserManager _userManager;
        public AuthenticationManager()
        {
            _userManager = new UserManager();
        }


    }
}
