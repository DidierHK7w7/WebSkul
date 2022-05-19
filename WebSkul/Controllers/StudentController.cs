﻿using Microsoft.AspNetCore.Mvc;
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
