using Core.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeView.Utilities
{
    public class ValidNewEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string newEmail = value.ToString();
                //Console.WriteLine(newEmail);
                UserManager userManager = new UserManager();
                //string testUser = userManager.GetUser(newEmail).Email;
                
                if (userManager.GetUser(newEmail) == null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
