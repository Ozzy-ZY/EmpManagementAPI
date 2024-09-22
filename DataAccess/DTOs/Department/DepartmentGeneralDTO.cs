using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Department
{
    public record DepartmentGeneralDTO(
        int deptId,
        string name,
        string phone,
        int? managerId,
        string description,
        string location)
    {
        public int DeptId { get; set; } = deptId;
        public string Name { get; set; } = name;
        public string Phone { get; set; }  = phone;
        public int? ManagerId { get; set; } = managerId;
        public string Description { get; set; } = description;
        public string Location { get; set; } = location;
    }
}
