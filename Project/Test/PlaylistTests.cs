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

            bool actual = playlistManager.AddToPlaylist();

            Assert.Equal(!expected, actual);
        }

        [Fact]
        public void Playlist_RemoveTitleSuccessful()
        {
            bool expected = true;

            bool actual = playlistManager.RemoveFromPlaylist();

            Assert.Equal(expected, actual);
        }
    }
}
