using Microsoft.AspNetCore.Mvc;
using MVC_Assign3.Models;
using MVC_Assign3.ViewModels;

namespace MVC_Assign3.Controllers
{
    public class UserController : Controller
    {
        static List<User> users = new List<User>();

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                users.Add(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var existingUser = users.FirstOrDefault(u =>
                u.Email == user.Email && u.Password == user.Password);

            if (existingUser != null)
            {
                HttpContext.Session.SetString("UserEmail", existingUser.Email);
                return RedirectToAction("Profile");
            }

            ViewBag.Error = "Invalid Login";
            return View();
        }

        public IActionResult Profile()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (email == null)
                return RedirectToAction("Login");

            var user = users.FirstOrDefault(u => u.Email == email);

            var vm = new UserViewModel
            {
                Name = user.Name,
                Email = user.Email
            };

            return View(vm);
        }

        public IActionResult Edit()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            var user = users.FirstOrDefault(u => u.Email == email);

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User u)
        {
            var user = users.FirstOrDefault(x => x.Email == u.Email);

            user.Name = u.Name;
            user.Password = u.Password;

            return RedirectToAction("Profile");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}