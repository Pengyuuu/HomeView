using Features.Playlist;

namespace Services.Contracts
{
    public interface IPlaylistService
    {
        bool CreatePlaylist(Playlist newPlaylist);

        bool DeletePlaylist(Playlist playlist);
    }
}
