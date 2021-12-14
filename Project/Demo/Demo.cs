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
            Console.WriteLine("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\..\\Homeview.mdf;Integrated Security=True");
            //User u = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345",new DateTime(2000, 12, 12), "mWallace", Role.User);
            User u = new User("vincent", "vega", "vvega@pulp.com", "iL0vem1@12345", new DateTime(2000, 12, 12), "vvega", Role.User);
            UserManager um = new UserManager();
            um.UserManagerCreateUser("TeamUnite", "Testing", u);

            
        }
    }
}
