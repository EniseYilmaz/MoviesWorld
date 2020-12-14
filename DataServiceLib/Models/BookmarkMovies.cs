namespace DataServiceLib.Models
{
    public class BookmarkMovies
    {
        public string UserName { get; set; }
        public string MovieId { get; set; }
        public TitleBasics Movie { get; set; }
    }
}
