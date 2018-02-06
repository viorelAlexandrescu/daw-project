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

            return CreatedAtRoute("GetMovie", new {
                id = movie.id
            }, movie);
        }

        [HttpGet]
        [Route("api/[controller]/all")]
        public JsonResult GetAll() 
        {
            var movies = new List < Movie > ();
            foreach(var movie in _context.Movies) 
            {
                movies.Add(movie);
            }
            return Json(movies);
        }

        [HttpGet]
        [Route("api/[controller]/latest")]
        public JsonResult GetLatest() 
        {
            var movies = new List < Movie > ();
            foreach(var movie in _context.Movies) 
            {
                if(movie.release == 2018 || movie.release == 2017)
                {
                    movies.Add(movie);
                }
            }
            return Json(movies);
        }

        [HttpGet("{id}")]
        [Route("api/[controller]/id")]
        public IActionResult GetById(int id) 
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

        [HttpGet("{languageId}")]
        [Route("api/[controller]/language")]
        public IActionResult GetByLanguage(int languageId) 
        {
            var movies = new List<Movie>();
            foreach(var movie in _context.Movies) 
            {
                foreach(var movieLanguage in movie.languageLink)
                {
                    if (movieLanguage.language.id == languageId) 
                    {
                        movies.Add(movie);
                    }
                }
            }
            if(movies.Count == 0){
                return NotFound();
            }
            return new ObjectResult(movies);
        }

        [HttpGet("{genreId}")]
        [Route("api/[controller]/genre")]
        public IActionResult GetByGenre(int genreId) 
        {
            var movies = new List<Movie>();
            foreach(var movie in _context.Movies) 
            {
                foreach(var movieGenre in movie.genreLink)
                {
                    if (movieGenre.genre.id == genreId) 
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

        [HttpGet("{awardId}")]
        [Route("api/[controller]/award")]
        public IActionResult GetByAward(int awardId) 
        {
            var movies = new List<Movie>();
            foreach(var movie in _context.Movies) 
            {
                foreach(var movieAward in movie.awardLink)
                {
                    if (movieAward.award.id == awardId) 
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

        [HttpGet("{release}")]
        [Route("api/[controller]/release")]
        public IActionResult GetByRelease(int release) 
        {
            var movies = new List<Movie>();
            foreach(var movie in _context.Movies) 
            {
                if(movie.release == release)
                {
                    movies.Add(movie);
                }
            }
            
            if(movies.Count == 0)
            {
                return NotFound();
            }
            return new ObjectResult(movies);
        }

        [HttpGet("{actorId}")]
        [Route("api/[controller]/actor")]
        public IActionResult GetByActor(int actorId) 
        {
            var movies = new List<Movie>();
            foreach(var movie in _context.Movies) 
            {
                foreach(var movieActor in movie.actorLink)
                {
                    if (movieActor.actor.id == actorId) 
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
        public IActionResult Update(int id, [FromBody] Movie movie) 
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
        public IActionResult Delete(int id) 
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