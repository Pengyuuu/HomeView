using System.Collections.Generic;

namespace Features.Playlist
{
    public class Playlist
    {
        /* Name of the playlist */
        public string Name { get; set; }

        /* The shows and movies that are in the playlist */
        public List<string> Titles { get; set; }

        /* Name of user playlist belongs to */
        public string DispName { get; set; }

        /* Default Playlist constructor */
        public Playlist()
        {
            Name = "";
            Titles = new List<string>();
            DispName = "";
        }

        public Playlist(string name, List<string> titles, string dispName)
        {
            Name = name;
            Titles = titles;
            DispName = dispName;
        }
    }
}
