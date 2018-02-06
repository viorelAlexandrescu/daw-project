using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace daw.Models
{
    public class Cast
    {
        [Key]
        public int movieId { get; set; }
        [Key]
        public int actorId { get; set; }

        public Movie movie { get; set; }
        public Actor actor { get; set; }
    }
    
}