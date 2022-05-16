using Microsoft.AspNetCore.Mvc;
using WebSkul.Models;

namespace WebSkul.Controllers
{
    public class SchoolController : Controller  //herencia de clase controller
    {
        public IActionResult Index()   //metodo de vista
        {
            var school = new School();
            school.SchoolId = Guid.NewGuid().ToString();
            school.Name = "Platzi School";
            school.FoundationYear = 2005;

            return View(school);  //retorna la vista
        }
    }
}
