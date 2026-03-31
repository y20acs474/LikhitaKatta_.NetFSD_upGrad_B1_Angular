using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    public IActionResult GetProduct(int id)
    {
        return Content($"Product Id is: {id}");
    }
}