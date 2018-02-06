using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace daw.Models
{
    public class Actor
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        public ICollection<Cast> movieLink { get; set; }
    }
}
