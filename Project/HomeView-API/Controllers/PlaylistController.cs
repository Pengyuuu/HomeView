using Microsoft.AspNetCore.Mvc;
using Managers.Contracts;
using Managers.Implementations;
using Features.Playlist;

namespace HomeView_API.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistManager _playlistManager;

        public PlaylistController()
        {
            _playlistManager = new PlaylistManager();
        }

        // POST: Create a new playlist
        [HttpPost("create/{email}/{playlistName}")]
        public ActionResult<bool> CreatePlaylist(string playlistName, string email, PlaylistViewMode viewMode)
        {
            if (!_playlistManager.ValidateName(playlistName, email))
            {
                return BadRequest("Please enter a valid name for your playlist");
            }
            
            if (!_playlistManager.CreatePlaylist(playlistName, email, viewMode))
            {
                return BadRequest("Error creating playlist");
            }

            return Ok("Playlist created");
        }

        // DELETE: User's playlist
        [HttpDelete("delete/playlist/user/{playlistTitle}/{email}")]
        public ActionResult<bool> DeletePlaylist(string playlistTitle, string email)
        {
            if (!_playlistManager.DeletePlaylist(playlistTitle, email))
            {
                return BadRequest($"Error deleting Playlist: {playlistTitle}");
            }

            return Ok($"Playlist: {playlistTitle} deleted");
        }


        // GET: User's playlists
        [HttpGet("get/playlist/{email}")]
        public ActionResult<Playlist> GetPlaylist(string email)
        {
            List<Playlist> playlists = (List<Playlist>) _playlistManager.GetPlaylist(email);

            if (playlists.Count() == 0)
            {
                return BadRequest("Error retrieving playlists or user has no playlists");
            }

            return Ok(playlists);
        }
    }
}
