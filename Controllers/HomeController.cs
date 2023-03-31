using Microsoft.AspNetCore.Mvc;
using StudentManagementSystemNew.Data;
using StudentManagementSystemNew.Models;
using System.Diagnostics;

namespace StudentManagementSystemNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            students = _context.Students.Where(x=>x.Name== "Rupesj").OrderBy(x=>x.Name).ToList();
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student obj)
        {
           _context.Students.Add(obj);
            var result = _context.SaveChanges();
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}