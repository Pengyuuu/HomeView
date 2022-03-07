using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.User;
using HomeView.Utilities;

namespace HomeView.Models
{
    public class HomeModel : IValidatableObject
    {
        
        [Required(ErrorMessage = "Email is required. ")]
        public string _userEmail { get; set; }

        // Passwords must have a minimum of 12 characters with one capital letter and one non-alphanumeric character
   
        [Required(ErrorMessage = "Password is required. ")]
        public string _userPass { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            UserManager userMan = new UserManager();
            
            var retrievedUser = userMan.GetUser(_userEmail);
            if ((retrievedUser == null) || (retrievedUser.Password != _userPass))
            {
                yield return new ValidationResult("Invalid email/password.");
            }
                       
        }

  
    }


}
