using Microsoft.AspNetCore.Mvc;

public class Sample8Controller : Controller
{
    public IActionResult Index8()
    {
        ViewData["Name"] = "John";
        ViewData["Age"] = 25;

        return View();
    }
}