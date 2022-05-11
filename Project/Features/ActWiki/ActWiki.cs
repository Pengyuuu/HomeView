using System.Collections.Generic;

namespace Features.ActWiki
{
    // Receiving information on given Actor / Actress per DB
    public class ActWiki
    {
        // ID represnting Actor / Actress
        public int id { get; set; }
        // Name of Actor / Actress
        public string name { get; set; }
        // Birthday of Actor / Actress
        public string birthday { get; set; }
        // Gender of Actor / Actress
        public int gender { get; set; }
        // Biography of Actor / Actress
        public string biography { get; set; }

        // Default Constructor for Actor / Actress
        public ActWiki()
        {
            id = 0;
            name = "";
            birthday = "";
            gender = 0;
            biography = "";

        }

        public ActWiki(int id, string name, string birthday, int gender, string biography)
        {
            this.id = id;
            this.name = name;
            this.birthday = birthday;
            this.gender = gender;
            this.biography = biography;
        }

    }

}
