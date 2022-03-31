using System;
using System.IO;

namespace Data
{
    public class ConnectionString
    {
        static string connStr;
        public static string getConnectionString()
        {
            if (String.IsNullOrEmpty(connStr))
            {
                string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string path = (System.IO.Path.GetDirectoryName(executable));
                path = Path.GetFullPath(Path.Combine(path, "@\\..\\..\\..\\..\\..\\..\\Project\\Data\\Database\\Homeview.mdf"));
                //connStr = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =" + path + "; Integrated Security = True; Connect Timeout = 30";
                
            }
            return connStr;
        }



    }
}
