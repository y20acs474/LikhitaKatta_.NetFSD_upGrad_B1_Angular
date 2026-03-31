using Microsoft.AspNetCore.Mvc;
using MVC_Assign2.Models;
using System.Collections.Generic;

namespace MVC_Assign2.Controllers
{
    public class StudentController : Controller
    {
        // Temporary data (instead of database)
        static List<Student> students = new List<Student>();

        // READ - Display list
        public IActionResult Index()
        {
            return View(students);
        }

        // CREATE - GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        public IActionResult Create(Student s)
        {
            students.Add(s);
            return RedirectToAction("Index");
        }
    }
}