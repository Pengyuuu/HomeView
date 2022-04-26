using System.Collections.Generic;

namespace Features.Playlist
{
    public class Playlist
    {
        /* ID number of the playlist, used to grab it's movies and shows */
        public int playlistID { get; set; }

        /* Name of the playlist */
        public string playlistName { get; set; }

        /* The shows and movies that are in the playlist */
        public List<PlaylistTitle> Titles { get; set; }

        /* Email of the user playlist belongs to */
        public string Email { get; set; }

        public PlaylistViewMode ViewMode { get; set; }

        /* Default Playlist constructor */
        public Playlist()
        {
            playlistID = 0;
            playlistName = "";
            Titles = new List<PlaylistTitle>();
            Email = "";
            ViewMode = PlaylistViewMode.Public;
        }

        public Playlist(int id, string name, List<PlaylistTitle> titles, string email, PlaylistViewMode viewMode)
        {
            playlistID = id;
            playlistName = name;
            Titles = titles;
            Email = email;
            ViewMode = viewMode;
        }
    }
}