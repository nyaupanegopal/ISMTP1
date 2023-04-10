namespace StudentManagementSystemNew.Models
{
    public class StudentRegister
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public int Department { get; set; }
        public string[] OptionalSub { get; set; }
        public string Message { get; set; }
    }
}
