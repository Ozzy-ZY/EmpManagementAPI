using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Employee
{
    public class EmployeeAddDTO
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; } 
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; } 
    }
}
