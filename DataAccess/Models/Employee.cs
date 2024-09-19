using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public required DateTime JoinedAt { get; set; } = DateTime.Now;

        public required int DepartmentId { get; set; }
        public required virtual Department Department { get; set; }


    }
}
