using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using daw.Models;
using daw.Data;
namespace daw.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly MovieContext _context;

        public HomeController(MovieContext context)
        {
            _context = context;
        }

        [HttpGet("action")]
        public IEnumerable<Movie> getLatest()
        {
            return _context.Movies;
        }
    }
}
