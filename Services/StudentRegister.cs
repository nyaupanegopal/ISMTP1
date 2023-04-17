using StudentManagementSystemNew.Data;
using StudentManagementSystemNew.Models;

namespace StudentManagementSystemNew.Services
{
    public class StudentRegister:IStudentRegister
    {
        private readonly ApplicationDbContext _context;
        public StudentRegister(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Department> FetchDepartmentList()
        {
            return _context.Departments.ToList();
        }
    }
}
