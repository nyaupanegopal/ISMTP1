using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementSystemNew.Data;
using StudentManagementSystemNew.Models;
using StudentManagementSystemNew.Services;
using StudentRegister = StudentManagementSystemNew.Models.StudentRegister;

namespace StudentManagementSystemNew.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudentRegister _studentRegister;
        public StudentController(ApplicationDbContext context, IStudentRegister student)
        {
            _studentRegister = student;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            ViewBag.OptSub = _context.OptionalSubjects.ToList();
            var data = _studentRegister.FetchDepartmentList();  
             ViewBag.DepartmentData = new SelectList(data, "Id", "DepartmentName");
            return View();
        }
        [HttpPost]
        public IActionResult Register(StudentRegisterViewModel obj)
        {
            //View model to model mapping
            StudentRegister student = new StudentRegister();
            student.Name = obj.Name;
            student.Email = obj.Email;
            student.Phone = obj.Phone;
            student.Department=obj.Department;
            student.Gender = obj.Gender;
            student.Message = obj.Message;
            
            _context.StudentRegisters.Add(student);
            var result=_context.SaveChanges();

            foreach (var registration in obj.OptionalSub)
            {
                StudentOPTSubjectMapping optsub = new StudentOPTSubjectMapping();
                optsub.SubjectName = registration;
                optsub.StudentId=student.Id;
                _context.StudentOPTSubjectMappings.Add(optsub);
            }
            var result1=_context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
