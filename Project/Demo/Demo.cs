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

            UserManager um = new UserManager("TeamUnite", "Testing");

            Console.WriteLine(um.UserManagerGetAllUsers());

        }
    }
}
