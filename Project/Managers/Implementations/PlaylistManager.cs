using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers.Contracts;
using Services.Contracts;
using Services.Implementations;
using Core.Logging;
using Features.Playlist;

namespace Managers.Implementations
{
    public class PlaylistManager : IPlaylistManager
    {
        private readonly IPlaylistManager _playlistManager;
        private readonly IPlaylistService _playlistService;
        private readonly ILoggingManager _loggingManager;

        public PlaylistManager()
        {
            _playlistService = new PlaylistService();
            _loggingManager = new LoggingManager();
        }

        public bool ValidateName(string playlistName, string dispName)
        {
            if (playlistName == "")
            {
                _loggingManager.LogData(
                    $"User: {dispName} Playlist {playlistName} blank or invalid", 
                    LogLevel.Error, 
                    LogCategory.Data, 
                    DateTime.UtcNow);

                return false;
            }
            return true;
        }

        public bool CreatePlaylist(string playlistName, string dispName, PlaylistViewMode viewMode)
        {
            if (!ValidateName(playlistName, dispName))
            {
                return false;
            }

            Playlist newPlaylist = new Playlist(playlistName, null, dispName, viewMode);

            return _playlistService.CreatePlaylist(newPlaylist);
        }

        public bool DeletePlaylist(string playlistName, string dispName)
        {
            Playlist targetPlaylist = new Playlist();
            targetPlaylist.Name = playlistName;
            targetPlaylist.DispName = dispName;

            return _playlistService.DeletePlaylist(targetPlaylist);
        }
    }
}
