using System.Collections.Generic;
using System.Linq;
using Xunit;
using Features.Playlist;
using Managers.Implementations;
using System;

namespace PlaylistTests
{
    public class PlaylistTests
    {
        PlaylistManager playlistManager = new PlaylistManager();

        [Fact]
        public void Playlist_CreatePlaylistSuccessful()
        {
            bool expected = true;

            bool actual = playlistManager.CreatePlaylist("Test Playlist 3", "testing@gmail.com", PlaylistViewMode.Private);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Playlist_DeletePlaylistSuccessful()
        {
            bool expected = true;

            bool actual = playlistManager.DeletePlaylist("Test Playlist", "testing@gmail.com");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Playlist_AddTitleSuccessful()
        {
            bool expected = true;

            bool actual = playlistManager.AddToPlaylist(1, "Tenet", "2020");

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Playlist_RemoveTitleSuccessful()
        {
            bool expected = true;

            bool actual = playlistManager.RemoveFromPlaylist(2, "The Fast and The Furious", "2001");

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Playlist_GetUsersPlaylistSuccessful()
        {
            IEnumerable<Playlist> result = playlistManager.GetPlaylist("testing@gmail.com");

            var playlist = result.First();

            playlist = result.Last();

            Assert.True(result.Any());
        }
    }
}