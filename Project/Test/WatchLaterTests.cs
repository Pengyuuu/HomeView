using System.Collections.Generic;
using System.Linq;
using Features.WatchLater;
using Xunit;
using Managers.Implementations;

namespace WatchLaterTest
{
    public class WatchLaterTests
    {
        WatchLaterManager watchLaterManager = new WatchLaterManager();

        [Fact]
        public void WatchLater_AddToWatchLaterSuccessful()
        {
            bool expected = true;

            bool actual = watchLaterManager.AddToWatchLater("testing@gmail.com", "Tenet", "2020");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WatchLater_AddDuplicateUnsuccessful()
        {
            bool expected = false;

            bool actual = watchLaterManager.AddToWatchLater("testing@gmail.com", "Tenet", "2020");

            Assert.Equal(!expected, actual);
        }

        [Fact]
        public void WatchLater_RemoveFromListSuccessful()
        {
            bool expected = true;

            bool actual = watchLaterManager.RemoveFromList("testing@gmail.com", "Tenet", "2020");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WatchLater_GetListSuccessful()
        {
            List<WatchLaterTitle> result = watchLaterManager.GetList("testing@gmail.com");

            Assert.True(result.Any());
        }
    }
}
