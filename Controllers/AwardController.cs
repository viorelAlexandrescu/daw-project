using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using daw.Models;
using daw.Data;
namespace daw.Controllers {
    [Route("api/[controller]")]
    public class AwardController: Controller {
        private readonly MyContext _context;

        public AwardController(MyContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetAll() 
        {
            var awards = new List < Award > ();
            foreach(var award in _context.Awards) 
            {
                awards.Add(award);
            }
            return Json(awards);
        }
    }
}