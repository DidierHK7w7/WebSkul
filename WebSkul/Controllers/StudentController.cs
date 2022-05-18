using Microsoft.AspNetCore.Mvc;
using WebSkul.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebSkul.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var student = new Student { Name = "Ran Mitake", Id = Guid.NewGuid().ToString() };
            
            return View(student);
        }

        public IActionResult MultiStudent()
        {
            var studentList = RandomStudentsGenerator();

            return View(studentList);      //Indicamos la vista como parametro
        }

        private List<Student> RandomStudentsGenerator()
        {
            string[] firstName = { "Carl", "Big", "Cesar", "OG", "Wu", "Mike", "Madd" };
            string[] middleName = { "Mitake", "Hikawa", "Yamabuki", "Ichigaya", "Aoba", "Hitori", "Lawrence" };
            string[] lastName = { "Johnson", "Smoke", "Vialpando", "Loc", "Zi Mu", "Toreno", "Dogg" };
            //Producto cartesiano con LinQ
            var studentList = from n1 in firstName
                              from n2 in middleName
                              from a1 in lastName
                              select new Student { Name = $"{n1} {n2} {a1}",
                                                   Id = Guid.NewGuid().ToString() };

            return studentList.OrderBy((stn) => stn.Id).ToList();     //El delegado Obrder By ordena por el ide unico y Take trunca la lista de n alumnos a un numero especifico
        }
    }
}
