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
    }
}
