
namespace Features.Blacklist
{
    public class News
    {
    
        // maybe make read only or priv idk?
        public string blacklistItem { get; }
        public string dispName { get; }

        public News(string blacklistItem, string dispName)
        {
            this.blacklistItem = blacklistItem;
            this.dispName = dispName;
        }

    }


}
