using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystemNew.Models;

namespace StudentManagementSystemNew.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentRegister> StudentRegisters { get; set; }
        public DbSet<StudentOPTSubjectMapping> StudentOPTSubjectMappings { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}