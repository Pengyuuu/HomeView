using Features.Playlist;

namespace Managers.Contracts
{
    public interface IPlaylistManager
    {
        bool CreatePlaylist(string playlistName, string dispName, PlaylistViewMode viewMode);

        bool DeletePlaylist(string playlistName, string dispName);
    }
}
