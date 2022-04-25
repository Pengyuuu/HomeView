using Features.Playlist;
using Core.User;
using System.Collections.Generic;

namespace Services.Contracts
{
    public interface IPlaylistService
    {
        bool CreatePlaylist(Playlist newPlaylist);

        bool DeletePlaylist(Playlist playlist);

        bool AddToPlaylist(PlaylistTitle addTitle);

        bool RemoveFromPlaylist(PlaylistTitle targetTitle);

        IEnumerable<Playlist> GetPlaylist(Playlist targetPlaylist);
    }
}
