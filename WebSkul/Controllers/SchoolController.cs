using Microsoft.AspNetCore.Mvc;
using WebSkul.Models;
using System;
using System.Linq;

namespace WebSkul.Controllers
{
    public class SchoolController : Controller  //herencia de clase controller
    {
        private SchoolContext _context;
        public IActionResult Index()   //metodo de vista
        {
            ViewBag.DynamicThing = "Hello world xd";    //variable dinamica
            var school = _context.Schools.FirstOrDefault();     //Extrae la primera o default school de la base de datos
            return View(school);  //retorna la vista
        }
        public SchoolController(SchoolContext context)
        {
            _context = context;
        }
    }
}
