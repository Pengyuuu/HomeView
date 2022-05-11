using System;
using System.Collections.Generic;

namespace Core.UAD
{
    public class UADResponse
    {
        // registration count list
        public List<KeyValuePair<DateTime, int>> registrationCount { get; set; }

        // login count list
        public List<KeyValuePair<DateTime, int>> loginCount { get; set; }

        // news count list
        public List<KeyValuePair<DateTime, int>> newsCount { get; set; }

        // review count list
        public List<KeyValuePair<DateTime, int>> reviewCount { get; set; }

        // most viewed count list
        public List<int> topViewCount { get; set; }

        // duration view count list
        public List<double> durationViewCount { get; set; }

        public UADResponse()
        {
            this.registrationCount = null;
            this.loginCount = null;
            this.newsCount = null;
            this.reviewCount = null;
            this.topViewCount = null;
            this.durationViewCount = null;
        }

        public UADResponse(List<KeyValuePair<DateTime, int>> regCount, List<KeyValuePair<DateTime, int>> logCount, List<KeyValuePair<DateTime, int>> nCount, List<KeyValuePair<DateTime, int>> revCount, List<int> viewCount, List<double> dCount)
        {
            this.registrationCount = regCount;
            this.loginCount = logCount;
            this.newsCount = nCount;
            this.reviewCount = revCount;
            this.topViewCount = viewCount;
            this.durationViewCount = dCount;

        }
    }
}
