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

        [Required(ErrorMessage = "Password is required. ")]
        public string _userPass { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            UserManager userMan = new UserManager();
            
            var retrievedUser = userMan.GetUser(_userEmail);
            if ((retrievedUser == null) || (retrievedUser.Password != _userPass))
            {
                yield return new ValidationResult("Invalid username or password provided. Retry again or contact system administrator");
            }
            else
            {
                if (!retrievedUser.Status)
                {
                    yield return new ValidationResult("Email Confirmation Pending.");
                }
            }                     
        }
    }
}
