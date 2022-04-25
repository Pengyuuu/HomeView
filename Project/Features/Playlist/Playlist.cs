using System.Collections.Generic;

namespace Features.Playlist
{
    public class Playlist
    {
        /* ID number of the playlist, used to grab it's movies and shows */
        public int ID { get; set; }

        /* Name of the playlist */
        public string Name { get; set; }

        /* The shows and movies that are in the playlist */
        public List<string> Titles { get; set; }

        /* Email of the user playlist belongs to */
        public string Email { get; set; }

        public PlaylistViewMode ViewMode { get; set; }

        /* Default Playlist constructor */
        public Playlist()
        {
            ID = 0;
            Name = "";
            Titles = new List<string>();
            Email = "";
            ViewMode = PlaylistViewMode.Public;
        }

        public Playlist(int id, string name, List<string> titles, string email, PlaylistViewMode viewMode)
        {
            ID = id;
            Name = name;
            Titles = titles;
            Email = email;
            ViewMode = viewMode;
        }
    }
}
