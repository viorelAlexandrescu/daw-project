namespace daw.Models
{
    public class Watchlist
    {
        public int movieId { get; set; }
        public int userId { get; set; }
        public Movie movie { get; set; }
        public User user { get; set; }
    }
}