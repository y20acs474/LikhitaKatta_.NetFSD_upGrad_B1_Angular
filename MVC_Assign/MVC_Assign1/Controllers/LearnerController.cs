using Microsoft.AspNetCore.Mvc;

namespace MVC_Assign1.Controllers
{
    public class LearnerController : Controller
    {
        public IActionResult Details(String Name,int Age)
        {
            ViewData["name"] = "LIKHITA";
            ViewData["age"] = 22;
            return View();
        }
    }
}
