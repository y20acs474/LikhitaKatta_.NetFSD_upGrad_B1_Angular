using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    public IActionResult Details(string name, int age)
    {
        return Content($"Name: {name}, Age: {age}");
    }
}