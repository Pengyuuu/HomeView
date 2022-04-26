using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.ActWiki
{
    public class ActWiki
    {
        public string actName {get; set};
        public DateTime actBirth{get; set};
        public string actGender{get; set};
        public string actBiography{get; set};

        public ActWik()
        {
            actName = "";
            actBirth = new DateTime();
            actGender = "";
            actBiography = "";
        }

        public ActWiki(string name, DateTime birth, string gender, string bio)
        {
            actName = name;
            actBirth = birth;
            actGender = gender;
            actBiography = bio;
        }
    }
}
