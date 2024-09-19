using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Department
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Location { get; set; } = "New York";

        public required string Phone { get; set; }

        public required int ManagerId { get; set; }

        public required virtual Employee Manager { get; set; }

        public required virtual ICollection<Employee> Employees { get; set; }
    }
}
