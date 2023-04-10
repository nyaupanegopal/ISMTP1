using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystemNew.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
