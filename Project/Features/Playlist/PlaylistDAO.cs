using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                dispName = playlist.DispName
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

        public async void AsyncDeletePlaylist(Playlist playlist)
        {
            var targetPlaylist = new
            {
                name = playlist.Name,
                dispName = playlist.DispName
            };

            await _db.SaveData("dbo.Playlist_DeletePlaylist", targetPlaylist);
        }
    }
}
