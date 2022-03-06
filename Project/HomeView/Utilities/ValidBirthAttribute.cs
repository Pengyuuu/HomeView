using Core.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeView.Utilities
{
    public class ValidBirthAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                const int MINIMUM_AGE = 13;
                DateTime presentTime = DateTime.Today;
                DateTime userBirth = (DateTime) value;
                int age = presentTime.Year - userBirth.Year;
                if (age >= MINIMUM_AGE)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
