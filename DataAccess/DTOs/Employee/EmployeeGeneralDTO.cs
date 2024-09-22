using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Employee
{
    public record EmployeeGeneralDTO(
        int employeeId,
        string firstName,
        string lastName,
        string email,
        string title,
        string phone,
        string city,
        decimal salary,
        int departmentId)
    {
        public int Id { get; set; } = employeeId;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Email { get; set; } = email;
        public string Title { get; set; } = title;
        public string Phone { get; set; } = phone;
        public string City { get; set; } = city;
        public decimal Salary { get; set; } = salary;
        public int DepartmentId { get; set; } = departmentId;
    }
}
