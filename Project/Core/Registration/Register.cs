using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.User;

namespace Core.Registration
{
    class Register
    {
        public Register()
        {
        }

        /*
        public bool IsPasswordValid(string passPhrase)
        {
            if (passPhrase.Length >= 8)
            {
                for (int i = 0; i < passPhrase.Length; i++)
                {
                    foreach (char c in passPhrase)
                    {
                        if ((c >= 'a' && c <= 'x') || (c >= 'A' &&))
                    }
                }
            }
        }
        */
        public bool IsPassWordValid(string passPhrase)
        {
            // makes sure new user's password is valid (contains minimum of 12 characters, at least 1 capital letter, at least 1 non-alphanumeric character           
            int PASS_MIN_LENGTH = 12;
            Boolean containsUpper = false;
            Boolean containsNonAlpha = false;
            Boolean hasLength = false;

            // ensures password meets length requirement
            if (passPhrase.Length >= PASS_MIN_LENGTH)
            {
                hasLength = true;
                // ensures pasword meets capital and non-alphanumeric requirement
                for (int i = 0; i < passPhrase.Length; i++)
                {
                    if (Char.IsUpper(passPhrase[i]))
                    {
                        containsUpper = true;
                    }

                    if (!Char.IsLetterOrDigit(passPhrase[i]))
                    {
                        containsNonAlpha = true;
                    }
                }
            }           
            return hasLength == containsUpper == containsNonAlpha;
        }

        public bool IsEmailValid(string inputEmail)
        {
            //  makes sure new user's userEmail is valid (contains @.com)
            return (inputEmail.Contains("@") == inputEmail.Contains(".com"));
        }

        public bool RegisterUser(string userEmail, string userPass)
        {

        }
    }
}
