using Core.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Managers.Implementations;

namespace HomeView.Utilities
{
    public class ValidNewDisplayAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string newDisplay = value.ToString();
                UserManager userManager = new UserManager();
                if (userManager.DisplayGetUser(newDisplay) == null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
