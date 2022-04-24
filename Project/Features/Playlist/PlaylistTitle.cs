namespace Features.Playlist
{
    public class PlaylistTitle
    {
        public int PlaylistId { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }

        public PlaylistTitle()
        {
            PlaylistId = 0;
            Title = "";
            Year = "";
        }

        public PlaylistTitle(int PlaylistId, string Title, string Year)
        {
            this.PlaylistId = PlaylistId;
            this.Title = Title;
            this.Year = Year;
        }
    }
}
