using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Managers.Contracts;
using Managers.Implementations;

namespace UADTests
{
    public class UADTests
    {
        private UADManager _uadManager = new UADManager();


        [Fact]
        public void UAD_ShouldGetRegisterCountHistory()
        {
            var registerCount = _uadManager.GetRegistrationCountAsync().Result;
            var check = registerCount;
            
            Assert.NotNull(registerCount);

        }

        [Fact]
        public void UAD_ShouldGetReviewCountHistory()
        {
            var reviewCount = _uadManager.GetReviewCountAsync().Result;
            var check = reviewCount;

            Assert.NotNull(reviewCount);

        }

        [Fact]
        public void UAD_ShouldGetNewsCountHistory()
        {
            var reviewCount = _uadManager.GetReviewCountAsync().Result;
            var check = reviewCount;

            Assert.NotNull(reviewCount);

        }

        [Fact]
        public void UAD_ShouldGetAllCounts()
        {
            var reviewCount = _uadManager.GetAllCountsAsync().Result;
            var check = reviewCount;

            Assert.NotNull(reviewCount);

        }

    }
}
