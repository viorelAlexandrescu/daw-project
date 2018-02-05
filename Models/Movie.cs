using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace daw.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public int release { get; set; }
        public string description { get; set; }
        public string cover_url { get; set; }
}
}
