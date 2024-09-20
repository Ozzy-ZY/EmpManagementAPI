using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Employee
{
    public class EmployeeGetDTO(string fullname, string title, int departmentId)
    {
        public string FullName { get; set; } = fullname;
        public string Title { get; set; } = title;
        public int DepartmentId{ get; set; } = departmentId;
    }
}
