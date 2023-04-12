using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemNew.Models;

namespace StudentManagementSystemNew.Controllers
{
    public class StudentController : Controller
    {
        //ApplicationD
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(StudentRegister obj)
        {
            return RedirectToAction("Index");
        }
    }
}
