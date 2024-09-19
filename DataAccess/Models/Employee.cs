namespace DataAccess.Models
{
    public class Employee
    {
        public required int Id { get; set; }
        public required string FName { get; set; }

        public required string LName { get; set; }

        public required string Title { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public required string City { get; set; } = "New York";

        public required decimal Salary { get; set; }

        public required DateTime JoinedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }

        public required int DepartmentId { get; set; }
        public required virtual Department Department { get; set; }

    }
}
