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
        [Required]
        public string _firstName { get; set; }
        [Required]
        public string _lastName { get; set; }
        [Required]
        [EmailAddress]
        public string _userEmail { get; set; }
        [Required]
        public string _userPass { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime _userDob { get; set; }
        [Required]
        public string _dispName { get; set; }

    }


}
