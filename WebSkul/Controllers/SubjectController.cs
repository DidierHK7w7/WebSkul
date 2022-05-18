using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebSkul.Models;

namespace WebSkul.Controllers
{
    public class SubjectController : Controller
    {
        private SchoolContext _context;

        [Route("Subject/Index/")]
        [Route("Subject/Index/{subjectId}")]

        public IActionResult Index(string subjectId)
        {
            if (!string.IsNullOrWhiteSpace(subjectId))       //Si subjectId no es nulo
            {
                ViewBag.DynamicThing = "Hello world xd";
                ViewBag.Date = DateTime.Now;
                var subject = from sub in _context.Subjects
                              where sub.Id == subjectId     //trae la asignatura que el id coincida con el id que pasemos
                              select sub;
                return View(subject.SingleOrDefault());  //Trae la primera o la asignatura por defecto de la db
            }
            else
            {
                return View("MultiSubject",_context.Subjects);  //Si subjectId es nulo, redirecciona a todas las asignaturas
            }
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
