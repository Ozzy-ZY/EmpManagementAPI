using DataAccess.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.ModelsExtentions
{
    public enum DtoOperation
    {
        Update,
        Create
    }
    public static class EmployeeExtentions
    {
        public static EmployeeGeneralDTO AsDTO(this Employee emp)
        {
            return new EmployeeGeneralDTO(
                emp.Id, emp.FName, emp.LName, emp.Email, emp.Title, emp.Phone, emp.City, emp.Salary, emp.DepartmentId);
        }
        public static Employee AsModel(this EmployeeGeneralDTO dto, DtoOperation operation) => operation switch
        {
            DtoOperation.Create => new Employee()
            {
                FName = dto.firstName,
                LName = dto.lastName,
                DepartmentId = dto.departmentId,
                Salary = dto.salary,
                Email = dto.email,
                City = dto.city,
                Phone = dto.phone
            },
            DtoOperation.Update => new Employee()
            {
                Id = dto.Id, 
                FName = dto.firstName,
                LName = dto.lastName,
                DepartmentId = dto.departmentId,
                Salary = dto.salary,
                Email = dto.email,
                City = dto.city,
                Phone = dto.phone,
                ModifiedAt = DateTime.Now
            },
            _ => throw new NotImplementedException(),
        };

    }
}
