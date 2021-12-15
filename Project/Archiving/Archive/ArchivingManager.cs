namespace Archive
{
    public class ArchivingManager
    {
        private static ArchivingManager instance = null;

        // Singleton design pattern, makes sure there's only one archiving
        public static ArchivingManager GetInstance
        {

            get
            {
                if (instance == null)
                {
                    instance = new ArchivingManager();
                }

                return instance;
            }
        }
    }
}
