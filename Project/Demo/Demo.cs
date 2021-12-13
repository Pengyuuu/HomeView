using System;
using System.Configuration;
using UM.User;

namespace Demo
{
    class Demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HomeView Milestone 3 Demo\n\n");
            Console.WriteLine(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            User u = new User("marsellus", "wallace", "mWallace@pulp.com", "iL0vem1@12345", new DateTime(1928374), "mWallace");
            UserManager um = new UserManager();
            um.UserManagerCreateUser(u);
        }
    }
}
