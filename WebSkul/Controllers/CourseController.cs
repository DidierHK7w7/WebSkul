using Microsoft.AspNetCore.Mvc;
using WebSkul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebSkul.Controllers
{
    public class CourseController : Controller
    {
        private SchoolContext _context;

        //[Route("Student/Index/")]       //permite no enviar el id como parametro
        //[Route("Student/Index/{subjectId}")]

        //Index
        public IActionResult Index(string id)
        {
            
            if (!string.IsNullOrWhiteSpace(id))
            {
                var course = from crs in _context.Courses
                              where crs.Id == id
                              select crs;
                return View(course.SingleOrDefault());
            }
            else
            {
                return View("MultiCourse", _context.Courses);
            }
        }

        //Multi curso
        public IActionResult MultiCourse()
        {
            return View(_context.Courses);      //Trae todos los alumnos de la db. Nota. se envia un dbset cuando requiere una lista, por lo que se cambia a ienumerable en la vista
        }

        //Crear curso
        public IActionResult Create()
        {
            ViewData["SchoolId"] = new SelectList(_context.Schools, "Id", "Name"); // "Id" es el valor a guardar, "Nombre" el valor a mostrar

            ViewBag.Date = DateTime.Now;
            ViewBag.DynamicThing = "Crear";
            return View();
        }

        [HttpPost]  //El metodo solo funcionara cuando la peticion sea por porst
        public async Task<IActionResult> Create(Course course)
        {
            ViewBag.Date = DateTime.Now;
            //if (ModelState.IsValid)
            //{
            //   
            //}
            //else
            //{
            //    return View(course);
            //}
            //var school = _context.Schools.FirstOrDefault();
            //course.SchoolId = school.Id;

            _context.Courses.Add(course);   //adiciona el courso q se pasa por parametro
            _context.SaveChanges();     //Guarda los cambios
            ViewBag.CourseCreated = "Curso creado";
            return View("index", course);
        }

        //Editar curso
        public IActionResult Update(string id)      //Editar curso
        {
            ViewData["SchoolId"] = new SelectList(_context.Schools, "Id", "Name");
            ViewBag.DynamicThing = "Editar";
            var Course = from cour in _context.Courses
                         where cour.Id == id
                         select cour;

            return View("Create", Course.SingleOrDefault());
        }
        [HttpPost]
        public IActionResult Update(Course newData, string id)
        {
            ViewData["SchoolId"] = new SelectList(_context.Schools, "Id", "Name");
            var CourseSearch = from cour in _context.Courses
                               where cour.Id == id
                               select cour;

            var Course = CourseSearch.SingleOrDefault();

            Course.Address = newData.Address;
            Course.Name = newData.Name;
            Course.Working = newData.Working;
            Course.SchoolId = newData.SchoolId;
            _context.SaveChanges();

            return View("index",newData);
        }

        //Eliminar curso
        public IActionResult Delete(string id)
        {
            var CourseSearch = from cour in _context.Courses
                               where cour.Id == id
                               select cour;
            _context.Courses.Remove(CourseSearch.FirstOrDefault());
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public CourseController(SchoolContext context)
        {
            _context = context;
        }
    }
}
