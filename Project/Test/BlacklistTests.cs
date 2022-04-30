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
            IEnumerable<string> actual = blacklistManager.GetBlacklist("HankHill@yahoo.com");
            Assert.True(actual.Any());
        }

        [Fact]
        public void BlacklistManager_RemoveFromBlacklistShouldRemoveFromBlacklist()
        {
            bool expected = true;
            bool actual = blacklistManager.RemoveFromBlacklist("HankHill@yahoo.com", "getlist2");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlacklistManager_ToggleBlacklistShouldToggleBlacklist()
        {
            bool expected = true;
            bool actual = blacklistManager.ToggleBlacklist("mWallace@pulp.com", true);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BlacklistManager_GetBlacklistToggleShouldToggleBlacklist()
        {
            bool? expected = false;
            bool? actual = blacklistManager.GetBlacklistToggle("HankHill@yahoo.com");

            Assert.Equal(expected, actual);

        }
    }
}
