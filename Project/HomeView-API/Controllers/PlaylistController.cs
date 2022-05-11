﻿using Microsoft.AspNetCore.Mvc;
using Managers.Contracts;
using Managers.Implementations;
using Features.Playlist;

namespace HomeView_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistManager _playlistManager;

        public PlaylistController(IPlaylistManager playlistManager)
        {
            _playlistManager = playlistManager;
        }

        // POST: Create a new playlist
        [HttpPost("create")]
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
        [HttpDelete("delete")]
        public ActionResult<bool> DeletePlaylist(string playlistTitle, string email)
        {
            if (!_playlistManager.DeletePlaylist(playlistTitle, email))
            {
                return BadRequest($"Error deleting Playlist: {playlistTitle}");
            }

            return Ok($"Playlist: {playlistTitle} deleted");
        }


        // GET: User's playlists
        [HttpGet("get")]
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
