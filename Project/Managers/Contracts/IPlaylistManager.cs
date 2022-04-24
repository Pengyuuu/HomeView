using Features.Playlist;
using System.Collections.Generic;

namespace Managers.Contracts
{
    public interface IPlaylistManager
    {
        bool CreatePlaylist(string playlistName, string dispName, PlaylistViewMode viewMode);

        bool DeletePlaylist(string playlistName, string dispName);

        bool AddToPlaylist(int playlistID, string title, string year);

        bool RemoveFromPlaylist(int playlistID, string title, string year);

        IEnumerable<Playlist> GetPlaylist(string dispName);
    }
}
