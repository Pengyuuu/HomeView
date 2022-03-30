using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Core.Archive
{
    public class Archived
    {
        private static Archived _instance = null;
        private List<string> _log = new List<string>();

       
        public Archived()
        {
        }
        

        // Singleton design pattern, makes sure there's only one archiving
        public static Archived GetInstance
        {

            get
            {
                if (_instance == null)
                {
                    _instance = new Archived();
                }

                return _instance;
            }
        }

        
    }
}
