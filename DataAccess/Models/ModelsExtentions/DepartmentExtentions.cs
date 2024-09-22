using DataAccess.DTOs.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.ModelsExtentions
{
    public static class DepartmentExtentions
    {
        public static DepartmentGeneralDTO AsDTO(this Department dept)
        {
            return new DepartmentGeneralDTO
                (dept.Id, dept.Name, dept.Phone, dept.ManagerId, dept.Description, dept.Location);
        }
        public static Department AsModel(this DepartmentGeneralDTO dto, DtoOperation operation) => operation switch {
            DtoOperation.Create => new Department()
            {
                Name = dto.name,
                Phone = dto.phone,
                ManagerId = dto.managerId,
                Location = dto.location,
                Description = dto.description
            },
            DtoOperation.Update => new Department()
            {
                Id = dto.deptId,
                Name = dto.name,
                Phone = dto.phone,
                ManagerId = dto.managerId,
                Location = dto.location,
                Description = dto.description
            },
            _ => throw new NotImplementedException()
        };
    }
}
