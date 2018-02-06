using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using daw.Models;
using daw.Data;
namespace daw.Controllers {
    [Route("api/[controller]")]
    public class GenreController: Controller {
        private readonly MyContext _context;

        public GenreController(MyContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetAll() 
        {
            var genres = new List < Genre > ();
            foreach(var genre in _context.Genres) 
            {
                genres.Add(genre);
            }
            return Json(genres);
        }
    }
}