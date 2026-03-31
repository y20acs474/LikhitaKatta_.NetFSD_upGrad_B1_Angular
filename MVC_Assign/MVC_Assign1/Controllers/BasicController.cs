using Microsoft.AspNetCore.Mvc;

namespace MVC_Assign1.Controllers
{
    public class BasicController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
