﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace daw.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }
        public ICollection<Watchlist> movieLink { get; set; }
    }
}
