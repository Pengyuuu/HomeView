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

        public IEnumerable<Playlist> GetPlaylist(string dispName)
        {
            return _playlistService.GetPlaylist(dispName);
        }
    }
}
