using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.User;

namespace HomeView.Models
{
    public class RegistrationModel
    {
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        public string _userEmail { get; set; }
        public string _userPass { get; set; }
        public DateTime _userDob { get; set; }
        public string _dispName { get; set; }

    }


}
