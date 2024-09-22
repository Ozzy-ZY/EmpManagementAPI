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
    { } 
}
