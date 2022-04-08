using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Features.Ratings_and_Reviews;
using Managers.Contracts;

namespace RatingReviewTests
{
    public class RatingReviewTests

    {

        private RatingAndReview testReview = new();
        private IR;

        [Fact]
        public void RatingReviewManager_getReviewShouldReturnReviewFromTable()
        {
            // arrange
            Log actual = testLog;

            //act
            logManager.LogData(testLog);
            actual = (Log)logManager.GetLog(384);

            //assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void RatingReviewManager_SubmitReviewShouldCreateReviewTableEntry()
        {
            bool expected = true;

            bool want = true;


            logManager.LogData(testLog);

            var retrievedLog = logManager.GetLog(testLog.timeStamp).Result;

            var result = testLog.timeStamp;

            foreach (var log in retrievedLog)
            {
                if (log.timeStamp != result)
                {
                    want = false;
                    break;
                }
            }

            Assert.Equal(expected, want);
        }

        [Fact]
        public void RatingReviewManager_DeleteReviewShouldDeleteReviewTableEntry()
        {

            bool expected = true;

            bool actual = logManager.DeleteOldLog();

            Assert.Equal(expected, actual);
        }
    }
}
