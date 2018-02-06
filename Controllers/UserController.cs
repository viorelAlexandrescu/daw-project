using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using daw.Models;
using daw.Data;
namespace daw.Controllers {
    [Route("api/[controller]")]
    public class UserController: Controller {
        private readonly MyContext _context;

        public UserController(MyContext context) 
        {
            _context = context;
        }

        private authenticate(User _user)
        {
            for(var user in _context.Users)
            {
                if((_user.username == user.username) && (_user.password == user.password))
                {
                    return true
                }
            }
            return false;
        }


        [HttpPost]
        [Route('api/{controller}/login')]
        public IActionResult login([FromBody] User Wuser)
        {
            if (user == null) 
            {
                return BadRequest();
            }

            if(authenticate(user))
            {
                return ObjectResult('Success!');
            }
            return ObjectResult('Bad Login');
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user) 
        {
            if (user == null) 
            {
                return BadRequest();
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtRoute("GetUser", new {
                id = user.id
            }, user);
        }

        [HttpGet("{userId}")]
        [Route("api/[controller]/watchlist")]
        public IActionResult GetWatchlist(int userId) 
        {
            var movies = new List<Movie>();
            foreach(var movie in _context.Movies) 
            {
                foreach(var movieUser in movie.userLink)
                {
                    if (movieUser.user.id == userId) 
                    {
                        movies.Add(movie);
                    }
                }
            }
            
            if(movies.Count == 0)
            {
                return NotFound();
            }
            return new ObjectResult(movies);
        }

        [HttpPut("{id}")]
        public IActionResult AddToWatchlist(int userId, [FromBody] Movie movie) 
        {
            foreach(var movieItem in _context.Movies) 
            {
                if(movieItem.id == movie.id)
                {
                    var item = new Watchlist(){
                        userId = userId,
                        movieId = movie.id
                    };
                    movieItem.userLink.Add(item);
                    return new ObjectResult(item);
                }      
            }

            return NotFound();
        }
    }
}