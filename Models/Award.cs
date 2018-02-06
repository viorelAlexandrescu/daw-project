using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace daw.Models
{
    public class Award
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }

        public ICollection<MovieAward> movieLink { get; set; }
    }
}
