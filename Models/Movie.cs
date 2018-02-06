using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace daw.Models
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public int release { get; set; }
        public string description { get; set; }
        public string cover_url { get; set; }
        public ICollection<Cast> actorLink { get; set; }
        public ICollection<MovieAward> awardLink { get; set; }
        public ICollection<MovieGenre> genreLink { get; set; }
        public ICollection<MovieLanguage> languageLink { get; set; }
        public ICollection<Watchlist> userLink { get; set; }
    }
}
