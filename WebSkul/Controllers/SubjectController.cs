using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSkul.Models;

namespace WebSkul.Controllers
{
    public class SubjectController : Controller
    {
        private SchoolContext _context;

        //[Route("Subject/Index/")]
        //[Route("Subject/Index/{subjectId}")]
        public IActionResult Index(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))       //Si subjectId no es nulo
            {
                ViewBag.DynamicThing = "Hello world xd";
                ViewBag.Date = DateTime.Now;
                var subject = from sub in _context.Subjects
                              where sub.Id == id     //trae la asignatura que el id coincida con el id que pasemos
                              select sub;
                return View(subject.SingleOrDefault());  //Trae la primera o la asignatura por defecto de la db
            }
            else
            {
                return View("MultiSubject",_context.Subjects);  //Si subjectId es nulo, redirecciona a todas las asignaturas
            }
        }

        //Multi asignatura
        public IActionResult MultiSubject()
        {
            return View(_context.Subjects);      //Trae todas las asignaturas de la db
        }

        //Crear asignatura
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name"); // "Id" es el valor a guardar, "Nombre" el valor a mostrar
            ViewBag.DynamicThing = "Crear";
            ViewBag.Date = DateTime.Now;
            return View();
        }

        [HttpPost]  //El metodo solo funcionara cuando la peticion sea por porst
        public async Task<IActionResult> Create(Subject subject)
        {
            ViewBag.Date = DateTime.Now;

            //var course = _context.Courses.FirstOrDefault();
            //subject.CourseId = course.Id;

            _context.Subjects.Add(subject);   //adiciona el courso q se pasa por parametro
            _context.SaveChanges();     //Guarda los cambios
            ViewBag.SubjectsCreated = "Alumno creado";
            return View("index", subject);
        }

        //Editar asignatura
        public IActionResult Update(string id)      //Editar curso
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewBag.DynamicThing = "Editar";
            var subject = from sbj in _context.Subjects
                          where sbj.Id == id
                          select sbj;

            return View("Create", subject.SingleOrDefault());
        }
        [HttpPost]
        public IActionResult Update(Subject newData, string id)
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            var subjectSearch = from sbj in _context.Subjects
                                where sbj.Id == id
                                select sbj;
            var subject = subjectSearch.SingleOrDefault();
            subject.Name = newData.Name;
            subject.CourseId = newData.CourseId;
            _context.SaveChanges();
            return View("index", newData);
        }

        //Eliminar curso
        public IActionResult Delete(string id)
        {
            var subjectSearch = from sbj in _context.Subjects
                                where sbj.Id == id
                                select sbj;
            _context.Subjects.Remove(subjectSearch.FirstOrDefault());
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public SubjectController(SchoolContext context)
        {
            _context = context;
        }
    }
}
