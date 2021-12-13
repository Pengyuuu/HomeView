using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unite.HomeView.Logging
{
    class Log
    {
        // Number identifier for the log
        public int Id { get; set; }

        // Title of user performing operation
        public string UserOperation { get; set; }

        // Description of operation
        public string Description { get; set; }

        // Level of the log
        public LogLevel Level { get; set; }

        // Category of log
        public LogCategory Category { get; set; }

        // Timestamp operation was performed
        public DateTime Timestamp { get; set; }
    }
}
