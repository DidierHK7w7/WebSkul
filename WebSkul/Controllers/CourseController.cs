﻿using Microsoft.AspNetCore.Mvc;
using WebSkul.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebSkul.Controllers
{
    public class CourseController : Controller
    {
        private SchoolContext _context;

        //[Route("Student/Index/")]       //permite no enviar el id como parametro
        //[Route("Student/Index/{subjectId}")]

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

        public IActionResult MultiCourse()
        {
            return View(_context.Courses);      //Trae todos los alumnos de la db. Nota. se envia un dbset cuando requiere una lista, por lo que se cambia a ienumerable en la vista
        }


        public IActionResult Create()
        {
            ViewBag.Date = DateTime.Now;
            return View();
        }

        [HttpPost]  //El metodo solo funcionara cuando la peticion sea por porst
        public async Task<IActionResult> Create(Course course)
        {
            ViewBag.Date = DateTime.Now;


            //if (ModelState.IsValid)
            //{
            //    var school = _context.Schools.FirstOrDefault();

            //    course.SchoolId = school.Id;
            //    _context.Courses.Add(course);   //adiciona el courso q se pasa por parametro
            //    await _context.SaveChangesAsync();     //Guarda los cambios
            //    ViewBag.CourseCreated = "Curso creado";
            //    return View("index", course);
            //}
            //else
            //{
            //    return View(course);
            //}

            var school = _context.Schools.FirstOrDefault();
            course.SchoolId = school.Id;
            _context.Courses.Add(course);   //adiciona el courso q se pasa por parametro
            _context.SaveChanges();     //Guarda los cambios
            ViewBag.CourseCreated = "Curso creado";

            return View("index", course);


        }

        public CourseController(SchoolContext context)
        {
            _context = context;
        }
    }
}
