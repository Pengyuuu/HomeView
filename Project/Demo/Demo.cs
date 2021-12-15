using System;
using System.Configuration;
using UM.User;
using Logging.Logging;

namespace Demo
{
    class Demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HomeView Milestone 3 Demo\n\n");

            LoggingManager lm = new();
            lm.logData(7357, LogUserOperation.Create, "Test log", LogLevel.Info, LogCategory.Data, new DateTime(2021, 12, 15));

        }
    }
}
