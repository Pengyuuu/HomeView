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

            UserManager userManage = new UserManager("TeamUnite", "Testing");
            LoggingManager logManager = new LoggingManager();

            User userTest = new User("Christian", "Lam", "ctlam@csulb.edu", "password", new DateTime(2000,01,01), "ctlam", 1, Role.User);

            Log test = new Log("test", LogLevel.Info, LogCategory.View, DateTime.UtcNow);

            logManager.LogData("test 2", LogLevel.Info, LogCategory.View, DateTime.UtcNow);
            logManager.LogData(test);

            //userManage.UserManagerCreateUser(userTest);

            //Console.WriteLine(userManage.UserManagerGetAllUsers());
        }
    }
}
