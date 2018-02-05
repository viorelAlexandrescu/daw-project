namespace daw.Models
{
    public class MovieAward
    {
        public int movieId { get; set; }
        public int awardId { get; set; }

        public Movie movie { get; set; }
        public Award award { get; set; }
    }
}