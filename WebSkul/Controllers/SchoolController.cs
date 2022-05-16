using Microsoft.AspNetCore.Mvc;

namespace WebSkul.Controllers
{
    public class SchoolController : Controller  //herencia de clase controller
    {
        public IActionResult School()   //metodo de vista
        {
            return View();  //retorna la vista
        }
    }
}
