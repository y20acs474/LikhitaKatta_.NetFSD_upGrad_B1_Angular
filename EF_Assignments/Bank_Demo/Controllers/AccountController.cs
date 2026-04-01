using Bank_Demo.Entities;
using Bank_Demo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountRepository _repo;

        public AccountController()
        {
            _repo = new AccountRepository();
        }

        public IActionResult Index()
        {
            var data = _repo.GetAccounts();
            return View(data);
        }

        public IActionResult Details(int id)
        {
            var acc = _repo.GetAccount(id);
            return View(acc);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account acc)
        {
            acc.CreateDate = DateTime.Now;
            _repo.AddAccount(acc);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var acc = _repo.GetAccount(id);
            return View(acc);
        }

        [HttpPost]
        public IActionResult Edit(Account acc)
        {
            _repo.UpdateAccount(acc);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repo.DeleteAccount(id);
            return RedirectToAction("Index");
        }
    }
}