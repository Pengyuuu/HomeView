using System.Collections.Generic;
using System.Threading.Tasks;
using Data;

namespace Features.Playlist
{
    public class PlaylistDAO
    {
        private readonly SqlDataAccess _db;

        public PlaylistDAO(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AsyncCreatePlaylist(Playlist playlist)
        {
            // Create a var object with the parameters for the stored procedure
            var newPlaylist = new
            {
                playlistName = playlist.playlistName,
                email = playlist.Email,
                viewMode = playlist.ViewMode,
            };

            /* 
             * var checkForPlaylist = new 
             * {
             * playlistName = playlist.PlaylistName,
             * email = playlist.Email
             * };
             * 
             * List<Playlist> duplicate = await _db.LoadData<Playlist, dynamic>("dbo.Playlist_GetPlaylist", checkForPlaylist);
             * 
             * 
            */
            var result = await _db.SaveData("dbo.Playlist_CreatePlaylist", newPlaylist);

            if (result != 1)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> AsyncDeletePlaylist(Playlist playlist)
        {
            // Create a var object with the parameters for the stored procedure
            var targetPlaylist = new
            {
                playlistName = playlist.playlistName,
                email = playlist.Email
            };

            // Need to use something else other than try and catch
            try
            {
                await _db.SaveData("dbo.Playlist_DeletePlaylist", targetPlaylist);

                return true;
            }
            
            catch
            {
                return false;
            }
        }

        public async Task<bool> AsyncAddTitleToPlaylist(PlaylistTitle title)
        {
            // Create a var object with the parameters for the stored procedure
            var addingTitle = new
            {
                playlistID = title.PlaylistId,
                title = title.Title,
                year = title.Year
            };

            // Need to use something else other than try and catch
            try
            {
                await _db.SaveData("dbo.Playlist_AddTitle", addingTitle);

                return true;
            }

            catch
            {
                return false;
            }
        }
        
        public async Task<bool> AsyncRemoveTitleFromPlaylist(PlaylistTitle title)
        {
            // Create a var object with the parameters for the stored procedure
            var removeTitle = new
            {
                playlistID = title.PlaylistId,
                title = title.Title,
                year = title.Year
            };

            // Need to use something else other than try and catch
            try
            {
                await _db.SaveData("dbo.Playlist_DeleteTitle", removeTitle);

                return true;
            }

            catch
            {
                return false;
            }
        }
        
        public async Task<IEnumerable<Playlist>> AsyncGetPlaylist(Playlist targetPlaylist)
        {
            // Create a var object with the parameters for the stored procedure
            var targetUser = new
            {
                email = targetPlaylist.Email
            };

            return await _db.LoadData<Playlist, dynamic>("dbo.Playlist_GetPlaylist", targetUser);
        }

        public async Task<IEnumerable<PlaylistTitle>> AsyncPopulatePlaylist(PlaylistTitle titles)
        {
            // Create a var object with the parameters for the stored procedure
            var targetPlaylist = new
            {
                playlistID = titles.PlaylistId
            };

            return await _db.LoadData<PlaylistTitle, dynamic>("dbo.Playlist_GetTitle", targetPlaylist);
        }
    }
}
