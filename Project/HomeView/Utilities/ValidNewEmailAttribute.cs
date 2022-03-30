using Core.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Managers.Implementations;

namespace HomeView.Utilities
{
    public class ValidNewEmailAttribute : ValidationAttribute
    {
        private UserManager _userManager = new UserManager();
        public override bool IsValid(object value)
        {

            if (value != null)
            {
                string newEmail = value.ToString();
                try
                {
                    if (_userManager.GetUser(newEmail) is null)
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
