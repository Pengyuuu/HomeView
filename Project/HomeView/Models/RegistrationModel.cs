using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.User;
using HomeView.Utilities;

namespace HomeView.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "First name is required. ")]
        public string _firstName { get; set; }

        [Required(ErrorMessage = "Last name is required. ")]
        public string _lastName { get; set; }


        [Required(ErrorMessage = "Email is required. ")]
        [EmailAddress(ErrorMessage = "Email must be a valid email address.")]
        [ValidNewEmail(ErrorMessage = "Email already in use.")]
        public string _userEmail { get; set; }

        // Passwords must have a minimum of 12 characters with one capital letter and one non-alphanumeric character
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[^a-zA-Z0-9]).{12,30}$",
            ErrorMessage = "Invalid Password. Must include: <br>• 12 Characters minimum <br>• 1 Capital letter minimum<br>• 1 Special character minimum")]
        [Required(ErrorMessage = "Password is required. ")]
        public string _userPass { get; set; }

        [Required(ErrorMessage = "Date Of Birth is required. ")]
        [DataType(DataType.Date)]
        public DateTime _userDob { get; set; }

        [Required(ErrorMessage = "Display name is required. ")]
        [StringLength(20, ErrorMessage="Display name must be at least 5 characters long. ", MinimumLength = 5)]
        [ValidNewDisplay(ErrorMessage = "Display name already in use.")]
        public string _dispName { get; set; }

    }


}
