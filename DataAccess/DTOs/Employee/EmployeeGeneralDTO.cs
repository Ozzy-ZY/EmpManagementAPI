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
    { }
}
