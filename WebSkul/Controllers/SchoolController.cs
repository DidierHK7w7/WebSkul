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
            //var school = new School();
            //school.UniqueId = Guid.NewGuid().ToString();
            //school.Name = "Platzi School";
            //school.CreationYear = 2005;
            //school.Address = "Groove Street";
            //school.Country = "Los Santos";
            //school.City = "San Andreas";
            //school.SchoolType = SchoolType.Middleschool;

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
