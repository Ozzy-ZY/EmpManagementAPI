namespace DataAccess.Models
{
    public class Department
    {
        public  int Id { get; set; }

        public  string Name { get; set; }

        public string Description { get; set; }

        public  string Location { get; set; } = "New York";

        public  string Phone { get; set; }

        public  int ManagerId { get; set; }

        public required virtual Employee Manager { get; set; }
        public required virtual ICollection<Employee> Employees { get; set; }
    }
}
