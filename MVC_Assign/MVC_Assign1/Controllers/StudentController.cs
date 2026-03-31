using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller
{
    public IActionResult Index()
    {
        return Content("Student Index Page");
    }

    public IActionResult Profile()
    {
        return Content("Student Profile Page");
    }
}