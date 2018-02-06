using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using daw.Models;
using daw.Data;
namespace daw.Controllers {
    [Route("api/[controller]")]
    public class LanguageController: Controller {
        private readonly MyContext _context;

        public LanguageController(MyContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetAll() 
        {
            var languages = new List < Language > ();
            foreach(var language in _context.Languages) 
            {
                languages.Add(language);
            }
            return Json(languages);
        }
    }
}