using Microsoft.AspNetCore.Mvc;
using WebSkul.Models;

namespace WebSkul.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            var subject = new Subject { UniqueId = Guid.NewGuid().ToString(), Name = "Video Games" };
            ViewBag.DynamicThing = "Hello world xd";
            ViewBag.Date = DateTime.Now;
            return View(subject);
        }

        public IActionResult MultiSubject()
        {
            var listSubjects = new List<Subject>(){
                    new Subject{Name = "Math", UniqueId = Guid.NewGuid().ToString()},
                    new Subject{Name = "English", UniqueId = Guid.NewGuid().ToString()},
                    new Subject{Name = "Videogames", UniqueId = Guid.NewGuid().ToString()},
                    new Subject{Name = "Music", UniqueId = Guid.NewGuid().ToString()},
                    new Subject{Name = "Web apps development", UniqueId = Guid.NewGuid().ToString()}
             };

            return View(listSubjects);      //Indicamos la vista como parametro
        }
    }
}
