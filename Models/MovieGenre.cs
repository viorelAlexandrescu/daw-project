using System.ComponentModel.DataAnnotations;

namespace daw.Models
{
    public class MovieGenre
    {
        [Key]
        public int movieId { get; set;}
        [Key]
        public int genreId { get; set; }

        public Movie movie { get; set; }
        public Genre genre { get; set; }
    }
}