using System;

namespace Archive
{
    public class Archiving
    {
        private static Archiving instance = null;

        // Singleton design pattern, makes sure there's only one archiving
        public static Archiving GetInstance
        {

            get
            {
                if (instance == null)
                {
                    instance = new Archiving();
                }

                return instance;
            }
        }
    }
}
