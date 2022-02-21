using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeView.Models
{
    public class RegistrationModel
    {
        public string _userEmail { get; set; }
        public string _userPass { get; set; }
        public Boolean _hasNewsletter { get; set; }


        /* Registers User by sending email to user's account
         *   User registers with a valid email and valid passphrase. A system message
         *   displays “Email confirmation pending”. The user receives a confirmation
         *   email within 15 seconds upon invocation of system message. The user 
         *   completes email confirmation within 24 hours. User is notified of username. 
         *   A system message displays “Account created successfully” 
        */

    }


}
