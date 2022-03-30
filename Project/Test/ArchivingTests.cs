using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Core.Archive;
using Managers.Contracts;
using Services.Contracts;


namespace ArchivingTesting
{
    public class ArchivingTests
    {
        [Fact]
        public void ArchivingManager_Send()
        {
            bool expected = true;
            //Archived test = new Archived();
            //bool actual = test.ArchiveLog();
            IArchivingService archivingService = null;
            bool actual = archivingService.ArchiveLog();
            Assert.Equal(expected, actual);
        }
    }
}
