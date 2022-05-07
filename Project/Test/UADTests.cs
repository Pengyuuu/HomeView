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
            var registerCount = _uadManager.GetRegistrationCount();
            List<int> check = registerCount;
            
            Assert.NotNull(registerCount);

        }

        [Fact]
        public void UAD_ShouldGetReviewCountHistory()
        {
            var reviewCount = _uadManager.GetReviewCount();
            List<int> check = reviewCount;

            Assert.NotNull(reviewCount);

        }

        [Fact]
        public void UAD_ShouldGetNewsCountHistory()
        {
            var reviewCount = _uadManager.GetReviewCount();
            List<int> check = reviewCount;

            Assert.NotNull(reviewCount);

        }

    }
}
