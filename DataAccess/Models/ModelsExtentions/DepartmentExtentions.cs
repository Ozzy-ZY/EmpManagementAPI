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
                Name = dto.Name,
                Phone = dto.Phone,
                ManagerId = dto.ManagerId,
                Location = dto.Location,
                Description = dto.Description
            },
            DtoOperation.Update => new Department()
            {
                Id = dto.deptId,
                Name = dto.Name,
                Phone = dto.Phone,
                ManagerId = dto.ManagerId,
                Location = dto.Location,
                Description = dto.Description
            },
            _ => throw new NotImplementedException()
        };
    }
}
