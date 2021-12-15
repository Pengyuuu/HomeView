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
            //User u = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345",new DateTime(2000, 12, 12), "mWallace", Role.User);
            User u = new User("vincent", "vega", "vvega@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "vvega", Role.User);
            UserManager um = new UserManager("TeamUnite", "Testing");
            um.UserManagerCreateUser(u);

            DateTime actualDate = new DateTime(2020, 8, 11);
            LoggingManager logManager = new LoggingManager();
            Boolean actual = logManager.Info(102, LogUserOperation.Create, "Test Log - LoggingManager Info()", LogLevel.Info, LogCategory.View, actualDate);
        }
    }
}
