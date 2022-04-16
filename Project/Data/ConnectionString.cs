using System;
using System.IO;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class ConnectionString
    {
        static string connStr;
        //private readonly IConfiguration config = new Con
        public static string getConnectionString()
        {
            if (String.IsNullOrEmpty(connStr))
            {
                string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string path = (System.IO.Path.GetDirectoryName(executable));
                path = Path.GetFullPath(Path.Combine(path, "@\\..\\..\\..\\..\\..\\..\\Project\\Data\\Database\\Homeview.mdf"));
                //connStr = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =" + path + "; Integrated Security = True; Connect Timeout = 30";

                /*
                var val = ConfigurationManager.AppSettings;
                var t = val.AllKeys;

                var section = ConfigurationManager.GetSection("ConnectionStrings");
                var test = ConfigurationManager.ConnectionStrings[0].ConnectionString;
                */
                
            }
            return connStr;
        }



    }
}
