using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Date)]
        public DateTime _userDob { get; set; }
        public string _dispName { get; set; }

    }


}
