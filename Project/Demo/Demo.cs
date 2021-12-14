using System;
using System.Configuration;
using UM.User;
using Logging.Logging;
using System.IO;

namespace Demo
{
    class Demo
    {
        static void Main(string[] args)
        {

            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\Data\Database"));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            //Console.WriteLine(AppDomain.CurrentDomain.GetData("DataDirectory"));


            Console.WriteLine("HomeView Milestone 3 Demo\n\n");
            //User u = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345",new DateTime(2000, 12, 12), "mWallace", Role.User);
            User u = new User("vincent", "vega", "vvega@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "vvega", Role.User);
            UserManager um = new UserManager("TeamUnite", "Testing");
            um.UserManagerCreateUser(u);

            
        }
    }
}
