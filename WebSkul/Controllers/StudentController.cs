using Microsoft.AspNetCore.Mvc;
using WebSkul.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebSkul.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext _context;

        //[Route("Student/Index/")]       //permite no enviar el id como parametro
        //[Route("Student/Index/{subjectId}")]

        //Index
        public IActionResult Index(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var student = from sdt in _context.Students
                              where sdt.Id == id
                              select sdt;
                return View(student.SingleOrDefault());
            }
            else
            {
                return View("MultiStudent", _context.Students);
            }
        }

        //Multi alumno
        public IActionResult MultiStudent()
        {
            return View(_context.Students);      //Trae todos los alumnos de la db. Nota. se envia un dbset cuando requiere una lista, por lo que se cambia a ienumerable en la vista
        }

        //Crear alumno
        public IActionResult Create()
        {
            ViewBag.Date = DateTime.Now;
            return View();
        }

        [HttpPost]  //El metodo solo funcionara cuando la peticion sea por porst
        public async Task<IActionResult> Create(Student student)
        {
            ViewBag.Date = DateTime.Now;

            var course = _context.Courses.FirstOrDefault();
            student.CourseId = course.Id;
            _context.Students.Add(student);   //adiciona el courso q se pasa por parametro
            _context.SaveChanges();     //Guarda los cambios
            ViewBag.StudentsCreated = "Alumno creado";
            return View("index", student);
        }

        //Editar alumno
        public IActionResult Update(string id)      //Editar curso
        {
            var student = from sdt in _context.Students
                         where sdt.Id == id
                         select sdt;

            return View("Create", student.SingleOrDefault());
        }
        [HttpPost]
        public IActionResult Update(Student newData, string id)
        {
            var studentSearch = from sdt in _context.Students
                                where sdt.Id == id
                               select sdt;
            var student = studentSearch.SingleOrDefault();
            student.Name = newData.Name;
            _context.SaveChanges();
            return View("index", newData);
        }

        //Eliminar curso
        public IActionResult Delete(string id)
        {
            var studentSearch = from sdt in _context.Students
                               where sdt.Id == id
                               select sdt;
            _context.Students.Remove(studentSearch.FirstOrDefault());
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public StudentController(SchoolContext context)
        {
            _context = context;
        }
    }
}
