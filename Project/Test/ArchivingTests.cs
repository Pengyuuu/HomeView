using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Archive;


namespace ArchivingTesting
{
    public class ArchivingTests
    {
        [Fact]
        public void ArchivingManager_Send()
        {
            bool expected = true;
            Archived test = new Archived();
            bool actual = test.ArchiveLog();
            Assert.Equal(expected, actual);
        }
    }
}
