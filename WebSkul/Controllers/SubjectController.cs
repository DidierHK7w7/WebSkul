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
    }
}
