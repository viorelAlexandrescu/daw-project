using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace daw.Models
{
    public class Genre
    {
        [Key]
        public int id { get; set; }
        public string genre{ get; set; }

        public ICollection<MovieGenre> movieLink { get; set; }
    }
}
