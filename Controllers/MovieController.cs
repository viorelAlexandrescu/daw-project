using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using daw.Models;
using daw.Data;
namespace daw.Controllers {
    [Route("api/[controller]")]
    public class MovieController: Controller {
        private readonly MyContext _context;

        public MovieController(MyContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Movie movie) 
        {
            if (movie == null) 
            {
                return BadRequest();
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new {
                id = movie.id
            }, movie);
        }

        [HttpGet]
        public IEnumerable < Movie > GetAll() 
        {
            var movies = new List < Movie > ();
            foreach(var movie in _context.Movies) 
            {
                movies.Add(movie);
            }
            return movies;
        }

        [HttpGet]
        [Route("api/[controller]/latest")]
        public IEnumerable < Movie > GetLatest() 
        {
            var movies = new List < Movie > ();
            foreach(var movie in _context.Movies) 
            {
                if(movie.release == 2018 || movie.release == 2017)
                {
                    movies.Add(movie);
                }
            }
            return movies;
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetById(long id) 
        {
            foreach(var movie in _context.Movies) 
            {
                if (movie.id == id) {
                    return new ObjectResult(movie);
                }
            }

            // var movie = _context.Movies.Find(id);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Movie movie) 
        {
            if (movie == null || movie.id != id) {
                return BadRequest();
            }

            foreach(var movieItem in _context.Movies) 
            {
                if (movieItem.id == id) {
                    movieItem.title = movie.title;
                    movieItem.release = movie.release;
                    movieItem.description = movie.description;
                    movieItem.cover_url = movie.cover_url;

                    _context.Movies.Update(movieItem);
                    _context.SaveChanges();

                    return new NoContentResult();
                }
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) 
        {
            foreach(var movie in _context.Movies) 
            {
                if (movie.id == id) {
                    _context.Movies.Remove(movie);
                    _context.SaveChanges();
                    return new NoContentResult();
                }
            } 
            return NotFound();
        }
    }
}