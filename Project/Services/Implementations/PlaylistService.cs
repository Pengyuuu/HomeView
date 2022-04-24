using Features.Playlist;
using Services.Contracts;
using Data;
using System.Collections.Generic;

namespace Services.Implementations
{
    public class PlaylistService : IPlaylistService
    {
        private PlaylistDAO _playlistDAO;

        public PlaylistService()
        {
            SqlDataAccess db = new SqlDataAccess();

            _playlistDAO = new PlaylistDAO(db);
        }

        public bool CreatePlaylist(Playlist newPlaylist)
        {
            return _playlistDAO.AsyncCreatePlaylist(newPlaylist).Result;
        }

        public bool DeletePlaylist(Playlist targetPlaylist)
        {
            return _playlistDAO.AsyncDeletePlaylist(targetPlaylist).Result;
        }

        public bool AddToPlaylist(PlaylistTitle playlistTitle)
        {
            return _playlistDAO.AsyncAddTitleToPlaylist(playlistTitle).Result;
        }

        public bool RemoveFromPlaylist(PlaylistTitle targetTitle)
        {
            return _playlistDAO.AsyncRemoveTitleFromPlaylist(targetTitle).Result;
        }

        public IEnumerable<Playlist> GetPlaylist(string dispName)
        {
            return _playlistDAO.AsyncGetPlaylist(dispName).Result;
        }
    }
}
