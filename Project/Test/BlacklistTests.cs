﻿using System.Collections.Generic;
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
        public async void BlacklistManager_AddToBlacklistShouldReturnBlacklist()
        {
            Blacklist user = new Blacklist("mWallace@pulp.com", "realmovietest");

            var actual = await blacklistManager.AddToBlacklistAsync(user);

            await blacklistManager.RemoveFromBlacklistAsync(user);

            Assert.NotNull(actual);
        }

        [Fact]
        public async void BlacklistManager_GetBlacklistShouldReturnBlacklist()
        {
            string user = "mWallace@pulp.com";
            
            var actual = await blacklistManager.GetBlacklistAsync(user);

            Assert.NotNull(actual);
        }
        
        [Fact]
        public async void BlacklistManager_RemoveFromBlacklistShouldReturnBlacklist()
        {
            Blacklist removeable = new Blacklist("mWallace@pulp.com", "illberemoved");
            await blacklistManager.AddToBlacklistAsync(removeable);

            var actual = await blacklistManager.RemoveFromBlacklistAsync(removeable);

            Assert.NotNull(actual);
        }
      
        [Fact]
        public async void BlacklistManager_UpdateToggleBlacklistShouldReturnToggleAndUser()
        {
            string userGet = "mWallace@pulp.com";
            var getToggle = await blacklistManager.GetBlacklistToggleAsync(userGet);
            bool expected = !getToggle.blacklistToggle;

            Blacklist userUpdate = new Blacklist("mWallace@pulp.com", !getToggle.blacklistToggle);
            var actual = await blacklistManager.UpdateToggleBlacklistAsync(userUpdate);

            Assert.Equal(expected, actual.blacklistToggle);
        }

        [Fact]
        public async void BlacklistManager_GetBlacklistToggleShouldReturnToggleAndUser()
        {
            bool expected = false;
            Blacklist user = new Blacklist("mWallace@pulp.com", false);
            await blacklistManager.UpdateToggleBlacklistAsync(user);

            var actual = await blacklistManager.GetBlacklistToggleAsync(user.dispName);

            Assert.Equal(expected, actual.blacklistToggle);
        }

        [Fact]
        public async void BlacklistManager_AddToBlacklistSHOULDFAIL()
        {
            // try catch 
            Blacklist user = new Blacklist("invalidUser", "nulltest");

            var actual = await blacklistManager.AddToBlacklistAsync(user);

            Assert.Null(actual);
        }

        [Fact]
        public async void BlacklistManager_GetBlacklistReturnNULL()
        {
            Blacklist user = new Blacklist("nullUser", "nulltest");

            var actual = await blacklistManager.GetBlacklistAsync(user.dispName);

            Assert.Null(actual.FirstOrDefault());
        }

        [Fact]
        public async void BlacklistManager_RemoveFromBlacklistReturnNULL()
        {
            Blacklist user = new Blacklist("nullUser", "nulltest");

            var actual = await blacklistManager.RemoveFromBlacklistAsync(user);

            Assert.Null(actual);
        }

        [Fact]
        public async void BlacklistManager_GetBlacklistToggleReturnNULL()
        {
            Blacklist user = new Blacklist("nullUser", "nulltest");

            var actual = await blacklistManager.GetBlacklistToggleAsync(user.dispName);

            Assert.Null(actual);
        }

        [Fact]
        public async void BlacklistManager_UpdateToggleBlacklistReturnNULL()
        {
            Blacklist user = new Blacklist("nullUser", "nulltest");

            var actual = await blacklistManager.UpdateToggleBlacklistAsync(user);

            Assert.Null(actual);
        }
    }
}
