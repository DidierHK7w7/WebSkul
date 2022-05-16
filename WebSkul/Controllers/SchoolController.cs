﻿using Microsoft.AspNetCore.Mvc;
using WebSkul.Models;

namespace WebSkul.Controllers
{
    public class SchoolController : Controller  //herencia de clase controller
    {
        public IActionResult Index()   //metodo de vista
        {
            var school = new School();
            school.UniqueId = Guid.NewGuid().ToString();
            school.Name = "Platzi School";
            school.CreationYear = 2005;

            ViewBag.DynamicThing = "Hello world xd";    //variable dinamica

            return View(school);  //retorna la vista
        }
    }
}
