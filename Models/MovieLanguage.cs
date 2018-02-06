using System.ComponentModel.DataAnnotations;

namespace daw.Models
{
    public class MovieLanguage
    {
        [Key]
        public int movieId { get; set; }
        [Key]
        public int languageId { get; set; }
        public Movie movie { get; set; }
        public Language language { get; set; }
    }
}