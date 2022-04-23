﻿using Features.Playlist;
using Services.Contracts;
using Data;

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
    }
}
