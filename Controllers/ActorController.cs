using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using daw.Models;
using daw.Data;
namespace daw.Controllers {
    [Route("api/[controller]")]
    public class ActorController: Controller {
        private readonly MyContext _context;

        public ActorController(MyContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetAll() 
        {
            var actors = new List < Actor > ();
            foreach(var actor in _context.Actors) 
            {
                actors.Add(actor);
            }
            return Json(actors);
        }
    }
}