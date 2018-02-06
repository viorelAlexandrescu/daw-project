using System.ComponentModel.DataAnnotations;

namespace daw.Models
{
    public class Watchlist
    {
        [Key]
        public int movieId { get; set; }
        [Key]
        public int userId { get; set; }
        public Movie movie { get; set; }
        public User user { get; set; }
    }
}