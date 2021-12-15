namespace Archiving.Archiving
{
    public class ArchivingService
    {
        private static ArchivingService instance = null;

        // Singleton design pattern, makes sure there's only one archiving
        public static ArchivingService GetInstance
        {

            get
            {
                if (instance == null)
                {
                    instance = new ArchivingService();
                }

                return instance;
            }
        }
    }
}
