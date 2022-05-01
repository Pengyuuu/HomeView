using System.Collections.Generic;
using System.Linq;
using Xunit;
using Features.Blacklist;
using Managers.Implementations;
using Managers.Contracts;
using Data;
using Services.Contracts;


namespace Test
{
    public class BlacklistTests
    {
        BlacklistManager blacklistManager = new BlacklistManager();
        private BlacklistDAO _bDAO;


        [Fact]
        public void BlacklistDAO_AddToBlacklist()
        {
            SqlDataAccess db = new SqlDataAccess();
            _bDAO = new BlacklistDAO(db);
            Blacklist test = new Blacklist("mWallace@pulp.com", "movieaddtest");
            int rowsEffected = _bDAO.AsyncAddToBlacklist(test).Result;

            Assert.Equal(1, rowsEffected);
        }

        [Fact]
        public void BlacklistManager_AddToBlacklistShouldAddToBlacklist()
        {
            System.Console.WriteLine("blacklist start add test");
            bool expected = true;
            bool actual = blacklistManager.AddToBlacklist("mWallace@pulp.com", "movieaddtest");
            System.Console.WriteLine("blacklist end add test");
            

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlacklistManager_GetBlacklistShouldReturnBlacklist()
        {
            IEnumerable<string> actual = blacklistManager.GetBlacklist("mWallace@pulp.com");
            Assert.True(actual.Any());
        }

        [Fact]
        public void BlacklistManager_RemoveFromBlacklistShouldRemoveFromBlacklist()
        {
            bool expected = true;

            blacklistManager.AddToBlacklist("mWallace@pulp.com", "getlist4");
            bool actual = blacklistManager.RemoveFromBlacklist("mWallace@pulp.com", "getlist4");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlacklistManager_ToggleBlacklistShouldToggleBlacklist()
        {
            bool expected = true;

            bool getToggle = blacklistManager.GetBlacklistToggle("mWallace@yahoo.com");
            bool actual = blacklistManager.ToggleBlacklist("mWallace@pulp.com", !getToggle);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlacklistManager_GetBlacklistToggleShouldToggleBlacklist()
        {
            bool expected = false;
            blacklistManager.ToggleBlacklist("mWallace@pulp.com", false);

            bool actual = blacklistManager.GetBlacklistToggle("mWallace@yahoo.com");

            Assert.Equal(expected, actual);

        }
    }
}
