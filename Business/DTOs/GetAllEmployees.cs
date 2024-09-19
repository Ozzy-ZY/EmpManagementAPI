using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class EmployeeAllGetDTO(string fullname, string title, string department)
    {
        public string FullName { get; set; } = fullname;
        public string Title { get; set; } = title;
        public string DepartmentName { get; set; } = department;
    }
}
