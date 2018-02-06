using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace daw.Models
{
    public class Language
    {
        public int id { get; set; }
        public string language { get; set ; }
        public ICollection<MovieLanguage> movieLink { get; set; }
    }
}