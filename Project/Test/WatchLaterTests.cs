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

            bool actual = watchLaterManager.AddToWatchLaterAsync("testing@gmail.com", "Star Wars: Episode IV – A New Hope", "1977").Result;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WatchLater_AddDuplicateUnsuccessful()
        {
            bool expected = false;

            bool actual = watchLaterManager.AddToWatchLaterAsync("testing@gmail.com", "Star Wars: Episode IV – A New Hope", "1977").Result;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WatchLater_RemoveFromListSuccessful()
        {
            bool expected = true;

            bool actual = watchLaterManager.RemoveFromListAsync("testing@gmail.com", "Star Wars: Episode IV – A New Hope", "1977").Result;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WatchLater_GetListSuccessful()
        {
            IEnumerable<WatchLaterTitle> result = watchLaterManager.GetListAsync("testing@gmail.com").Result;

            Assert.True(result.Any());
        }
    }
}
