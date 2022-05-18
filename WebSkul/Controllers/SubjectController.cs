using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebSkul.Models;

namespace WebSkul.Controllers
{
    public class SubjectController : Controller
    {
        private SchoolContext _context;
        public IActionResult Index()
        {
            ViewBag.DynamicThing = "Hello world xd";
            ViewBag.Date = DateTime.Now;
            return View(_context.Subjects.FirstOrDefault());  //Trae la primera o la asignatura por defecto de la db
        }

        public IActionResult MultiSubject()
        {
            return View(_context.Subjects);      //Trae todas las asignaturas de la db
        }

        public SubjectController(SchoolContext context)
        {
            _context = context;
        }
    }
}
