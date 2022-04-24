using System.Collections.Generic;
using System.Linq;
using Xunit;
using Features.Playlist;
using Managers.Implementations;

namespace PlaylistTests
{
    public class PlaylistTests
    {
        PlaylistManager playlistManager = new PlaylistManager();

        [Fact]
        public void Playlist_CreatePlaylistSuccessful()
        {
            bool expected = true;

            bool actual = playlistManager.CreatePlaylist("Test Playlist", "testName", PlaylistViewMode.Public);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Playlist_DeletePlaylistSuccessful()
        {
            bool expected = true;

            bool actual = playlistManager.DeletePlaylist("Test Playlist", "testName");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Playlist_AddTitleSuccessful()
        {
            bool expected = true;

            bool actual = playlistManager.AddToPlaylist(1, "The Fast and The Furious", "2001");

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Playlist_RemoveTitleSuccessful()
        {
            bool expected = true;

            bool actual = playlistManager.RemoveFromPlaylist(1, "Tenet", "2020");

            Assert.Equal(expected, actual);
        }

        public void Playlist_GetUsersPlaylistSuccessful()
        {
            IEnumerable<Playlist> result = playlistManager.GetPlaylist("testName");

            Assert.True(result.Any());
        }
    }
}
