namespace Features.WatchLater
{
    public class WatchLaterTitle
    {
        public string Email { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }

        public WatchLaterTitle()
        {
            Email = "";
            Title = "";
            Year = "";
        }

        public WatchLaterTitle(string email, string title, string year)
        {
            Email = email;
            Title = title;
            Year = year;
        }
    }
}
