using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementSystemNew.Data;
using StudentManagementSystemNew.Models;

namespace StudentManagementSystemNew.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            
            var data = _context.Departments.ToList();
             ViewBag.DepartmentData = new SelectList(data, "Id", "DepartmentName");
            return View();
        }
        [HttpPost]
        public IActionResult Register(StudentRegisterViewModel obj)
        {

            return RedirectToAction("Index");
        }
    }
}
