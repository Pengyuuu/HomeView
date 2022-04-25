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
            var newPlaylist = new
            {
                playlistName = playlist.Name,
                email = playlist.Email,
                viewMode = playlist.ViewMode,
            };
            try
            {
                await _db.SaveData("dbo.Playlist_CreatePlaylist", newPlaylist);

                return true;
            }

            catch
            {
                return false;
            }
        }

        public async Task<bool> AsyncDeletePlaylist(Playlist playlist)
        {
            var targetPlaylist = new
            {
                playlistName = playlist.Name,
                email = playlist.Email
            };

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
            var addingTitle = new
            {
                playlistID = title.PlaylistId,
                title = title.Title,
                year = title.Year
            };

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
            var removeTitle = new
            {
                playlistID = title.PlaylistId,
                title = title.Title,
                year = title.Year
            };

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
            var targetUser = new
            {
                email = targetPlaylist.Email
            };

            try
            {
                return await _db.LoadData<Playlist, dynamic>("dbo.Playlist_GetPlaylist", targetUser);
            }
            
            catch
            {
                return null;
            }
        }
    }
}
