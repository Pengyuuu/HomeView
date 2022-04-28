
namespace Features.Blacklist
{
    public class Blacklist
    {
    
        // maybe make read only or priv idk?
        public string blacklistItem { get; }
        public string dispName { get; }

        public Blacklist(string blacklistItem, string dispName)
        {
            this.blacklistItem = blacklistItem;
            this.dispName = dispName;
        }

    }


}
