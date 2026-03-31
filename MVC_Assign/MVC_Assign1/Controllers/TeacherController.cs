using Microsoft.AspNetCore.Mvc;

public class TeacherController : Controller
{
    public IActionResult Index()
    {
        return Content("Teacher Index Page");
    }

    public IActionResult Details()
    {
        return Content("Teacher Details Page");
    }
}