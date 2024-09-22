using DataAccess.DTOs.Department;
using DataAccess.Models;
using DataAccess.Models.ModelsExtentions;
using DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DepartmentManager
    {
        private readonly IRepo<Department> _repo;
        public DepartmentManager(IRepo<Department> repo)
        {
            _repo = repo;
        }
        public async Task<bool> AddDept(DepartmentGeneralDTO dto)
        {
            Department department = dto.AsModel(DtoOperation.Create);
            return await _repo.AddAsync(department);
        }
        public async Task<bool> UpdateDept(DepartmentGeneralDTO dto)
        {
            var dept = dto.AsModel(DtoOperation.Update);
            return await _repo.UpdateAsync(dept) != false;
        }
        public async Task<bool> DeleteDept(int id)
        {
            return await _repo.DeleteAsync(id) != false;
        }
        public async Task<IEnumerable<DepartmentGeneralDTO>> GetAllDepts(Expression<Func<Department, bool>> filter)
        {
            var dtoList = new List<DepartmentGeneralDTO>();
            var deptlist = await _repo.GetAllAsync(filter);
            // string name, string phone, int managerId,  string description = null!, string location = null!
            foreach (var dept in deptlist)
            {
                dtoList.Add(dept.AsDTO());
            }
            return dtoList;
        }
        public async Task<DepartmentGeneralDTO> GetDept(int id)
        {
            var dept = await _repo.GetAsync(id);
            return dept.AsDTO();
        }
    }
}
