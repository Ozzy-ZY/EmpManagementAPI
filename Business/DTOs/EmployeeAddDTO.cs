using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class EmployeeAddDTO(string firstname, string lastname, string email, string phone, int deptId)
    {
        public string FirstName { get; set; } = firstname;
        public string LastName { get; set; } = lastname;
        public string Email { get; set; } = email;
        public string Phone { get; set; } = phone;
        public int DepartmentId { get; set; } = deptId;
    }
}
