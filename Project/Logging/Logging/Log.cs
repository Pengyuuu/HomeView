﻿using System;

namespace Logging.Logging
{
    public class Log
    {
        // Number identifier for the log
        public int Id { get; set; }

        // Title of user performing operation
        public LogUserOperation UserOperation { get; set; }

        // Description of operation
        public string Description { get; set; }

        // Level of the log
        public LogLevel Level { get; set; }

        // Category of log
        public LogCategory Category { get; set; }

        // Timestamp operation was performed
        public DateTime timeStamp { get; set; }

        public Log(int id, LogUserOperation userOp, string desc, LogLevel level, LogCategory category, DateTime timeStamp)
        {
            this.Id = id;
            this.UserOperation = userOp;
            this.Description = desc;
            this.Level = level;
            this.Category = category;
            this.timeStamp = timeStamp;

        }
    }
}
