using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using daw.Models;
using daw.Data;
namespace daw.Controllers {
    [Route("api/[controller]")]
    public class MovieController: Controller {
        private readonly MyContext _context;

        public MovieController(MyContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable < Movie > GetAll() {
            var movies = new List < Movie > ();
            foreach(var movie in _context.Movies) {
                movies.Add(movie);
            }
            return movies;
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetById(long id) {
            foreach(var movie in _context.Movies) {
                if(movie.id == id){
                    return new ObjectResult(movie);
                }
            }

            // var movie = _context.Movies.Find(id);
            return NotFound();
        }
    }
}