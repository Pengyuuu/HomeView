using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Registration
{
    class Register
    {
        public Register()
        {
        }

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
    }
}
