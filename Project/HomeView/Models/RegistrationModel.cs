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
        [Required(ErrorMessage ="First name is required. ")]
        public string _firstName { get; set; }
        [Required(ErrorMessage = "Last name is required. ")]
        public string _lastName { get; set; }
        [Required(ErrorMessage = "Email is required. ")]
        [EmailAddress(ErrorMessage ="Email must be a valid email address.")]
        public string _userEmail { get; set; }
        [Required(ErrorMessage = "Password is required. ")]
        [StringLength(50, ErrorMessage= "Password must be at least 12 characters long. ", MinimumLength = 12)]
        public string _userPass { get; set; }
        [Required(ErrorMessage = "Date Of Birth is required. ")]
        [DataType(DataType.Date)]
        public DateTime _userDob { get; set; }
        [Required(ErrorMessage = "Display name is required. ")]
        [StringLength(20, ErrorMessage="Display name must be at least 10 characters long. ", MinimumLength = 10)]
        public string _dispName { get; set; }

    }


}
