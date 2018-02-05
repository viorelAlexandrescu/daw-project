namespace daw.Models
{
    public class MovieLanguage
    {
        public int movieId { get; set; }
        public int languageId { get; set; }
        public Movie movie { get; set; }
        public Language language { get; set; }
    }
}