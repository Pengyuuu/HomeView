using System;
using System.Collections.Generic;
using Core.User;
using Managers.Contracts;
using Services.Contracts;
using Services.Implementations;
using Core.Logging;
using Features.Playlist;

namespace Managers.Implementations
{
    public class PlaylistManager : IPlaylistManager
    {

        private readonly IPlaylistService _playlistService;
        private readonly ILoggingManager _loggingManager;

        public PlaylistManager()
        {
            _playlistService = new PlaylistService();
            _loggingManager = new LoggingManager();
        }

        public bool ValidateName(string playlistName, string email)
        {
            if (playlistName == "")
            {
                _loggingManager.LogData(
                    $"User: {email} Playlist {playlistName} blank or invalid", 
                    LogLevel.Error, 
                    LogCategory.Data, 
                    DateTime.UtcNow);

                return false;
            }
            return true;
        }

        public bool CreatePlaylist(string playlistName, string email, PlaylistViewMode viewMode)
        {
            if (!ValidateName(playlistName, email))
            {
                return false;
            }

            Playlist newPlaylist = new Playlist(0, playlistName, null, email, viewMode);

            return _playlistService.CreatePlaylist(newPlaylist);
        }

        public bool DeletePlaylist(string playlistName, string email)
        {
            Playlist targetPlaylist = new Playlist();
            targetPlaylist.playlistName = playlistName;
            targetPlaylist.Email = email;

            return _playlistService.DeletePlaylist(targetPlaylist);
        }

        
        public bool AddToPlaylist(int playlistID, string title, string year)
        {
            PlaylistTitle addTitle = new PlaylistTitle(playlistID, title, year);

            return _playlistService.AddToPlaylist(addTitle);
        }

        public bool RemoveFromPlaylist(int playlistID, string title, string year)
        {
            return _playlistService.RemoveFromPlaylist(new PlaylistTitle(playlistID, title, year));

            //PlaylistTitle targetTitle = new PlaylistTitle(playlistID, title, year);

            //return _playlistService.RemoveFromPlaylist(targetPlaylist);
        }
        
        public IEnumerable<Playlist> GetPlaylist(string email)
        {
            Playlist targetPlaylist = new Playlist();

            targetPlaylist.Email = email;

            return _playlistService.GetPlaylist(targetPlaylist);
        }

        public IEnumerable<PlaylistTitle> PopulatePlaylist(int playlistID)
        {
            PlaylistTitle targetPlaylist = new PlaylistTitle();

            targetPlaylist.PlaylistId = playlistID;

            return _playlistService.PopulatePlaylist(targetPlaylist);
        }
    }
}
