using System.ComponentModel.DataAnnotations;

namespace daw.Models
{
    public class MovieAward
    {
        [Key]
        public int movieId { get; set; }
        [Key]
        public int awardId { get; set; }

        public Movie movie { get; set; }
        public Award award { get; set; }
    }
}