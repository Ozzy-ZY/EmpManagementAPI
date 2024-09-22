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
        //public bool IsManager { get; set; } // TO-Do Change the Scheme so that when a manager is Deleted update the DepartmentManage
        // to be the CEO if the Company
        //public int IsCEO { get; set; }
        public required decimal Salary { get; set; }
        public required int DepartmentId { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }

        public virtual Department Department { get; set; }

    }
}
