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
            students = _context.Students.OrderBy(x=>x.Name).ToList();
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
        public IActionResult Edit( int id)
        {
            var data=_context.Students.Where(x=>x.Id==id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            var data= _context.Students.Where(x=>x.Id==obj.Id).FirstOrDefault();
            data.Name=obj.Name;
            data.Age=obj.Age;
            data.PhoneNo=obj.PhoneNo;
            _context.SaveChanges();

            return RedirectToAction("Index");
            
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            var data = _context.Students.Where(x => x.Id == id).First();
            _context.Students.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}