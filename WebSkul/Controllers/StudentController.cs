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
        public IActionResult Index()
        {
            return View(_context.Students.FirstOrDefault());    //Trae el primero o el alumno por defecto de la db
        }

        public IActionResult MultiStudent()
        {
            return View(_context.Students);      //Trae todos los alumnos de la db. Nota. se envia un dbset cuando requiere una lista, por lo que se cambia a ienumerable en la vista
        }

        public StudentController(SchoolContext context)
        {
            _context = context;
        }
    }
}
