namespace daw.Models
{
    public class MovieGenre
    {
        public int movieId { get; set;}
        public int genreId { get; set; }

        public Movie movie { get; set; }
        public Genre genre { get; set; }
    }
}