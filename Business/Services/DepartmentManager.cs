using Business.DTOs.Department;
using DataAccess.Models;
using DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    internal class DepartmentManager
    {
        private readonly IRepo<Department> _repo;
        public DepartmentManager(IRepo<Department> repo)
        {
            _repo = repo;
        }
        public async Task<bool> UpdateDept(DepartmentGeneralDTO dto)
        {
            var dept = new Department() { Name = dto.name, Description = dto.description, ManagerId = dto.managerId, };
            if (await _repo.UpdateAsync(dept) == false)
                return false;
            return true;

        }
        public async Task<bool> DeleteDept(int id)
        {
            if (await _repo.DeleteAsync(id) == false)
                return false;
            return true;
        }
        public async Task<IEnumerable<DepartmentGeneralDTO>> GetAllDepts(Expression<Func<Department, bool>> filter)
        {
            var dtoList = new List<DepartmentGeneralDTO>();
            var deptlist = await _repo.GetAllAsync(filter);
            // string name, string phone, int managerId,  string description = null!, string location = null!
            foreach (var dept in deptlist)
            {
                dtoList.Add(new DepartmentGeneralDTO(dept.Name, dept.Phone, dept.ManagerId, dept.Description, dept.Location));
            }
            return dtoList;
        }
        public async Task<DepartmentGeneralDTO> GetDept(int id)
        {
            var temp = await _repo.GetAsync(id);
            return new DepartmentGeneralDTO(temp.Name, temp.Phone, temp.ManagerId, temp.Description, temp.Location);
        }
    }
}
