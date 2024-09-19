using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Department
{
    public record DepartmentGeneralDTO(string name, string phone, int managerId,  string description = null!, string location = null!)
    {
    }
}
