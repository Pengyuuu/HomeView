using System.Collections.Generic;

namespace Features.ActWiki
{
    // Receiving information on given Actor / Actress per DB
    public class ActWiki
    {
        // ID represnting Actor / Actress
        public int ActID { get; set; }
        // Name of Actor / Actress
        public string ActName { get; set; }
        // Birthday of Actor / Actress
        public string ActBirth { get; set; }
        // Gender of Actor / Actress
        public int ActGender { get; set; }
        // Biography of Actor / Actress
        public string ActBio { get; set; }

        // Default Constructor for Actor / Actress
        public ActWiki()
        {
            ActID = 0;
            ActName = "";
            ActBirth = "";
            ActGender = 0;
            ActBio = "";
        }

        public ActWiki(string actName, string actBirth, int actGender, string actBio)
        {
            ActName = actName;
            ActBirth = actBirth;
            ActGender = actGender;
            ActBio = actBio;
        }
    }
}
