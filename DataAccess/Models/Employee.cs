namespace DataAccess.Models
{
    public class Employee
    {
        public  int Id { get; set; }
        public  string FName { get; set; }

        public  string LName { get; set; }

        public  string Title { get; set; }

        public  string Email { get; set; }

        public  string Phone { get; set; }

        public  string City { get; set; } = "New York";

        public required decimal Salary { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }

        public required int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

    }
}
