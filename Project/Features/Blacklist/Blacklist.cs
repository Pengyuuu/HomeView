
namespace Features.Blacklist
{
    public class Blacklist
    {
    
        // PascalCase members
        public string blacklistItem { get; set; }
        public string dispName { get; set; }
        public bool blacklistToggle { get; set; }

        // take out constructors
        public Blacklist(string dispName, string blacklistItem)
        {
            this.dispName = dispName;
            this.blacklistItem = blacklistItem;
        }

        public Blacklist(string dispName, bool toggleBlacklist)
        {
            this.dispName = dispName;
            this.blacklistToggle = toggleBlacklist;
        }

        public Blacklist(string dispName)
        {
            this.dispName=dispName;
        }

        public Blacklist() { }
    }


}
