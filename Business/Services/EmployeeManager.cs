using DataAccess.DTOs.Employee;
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
    public class EmployeeManager
    {
        private readonly IRepo<Employee> _repo;

        public EmployeeManager(IRepo<Employee> repo) {
            _repo = repo;
        }
        public async Task<bool> AddEmployee(EmployeeGeneralDTO dto)
        {
            return await _repo.AddAsync(dto.AsModel(DtoOperation.Create)) != false;
        }
        public async Task<bool> UpdateEmployee(EmployeeGeneralDTO dto)
        {
            
            return await _repo.UpdateAsync(dto.AsModel(DtoOperation.Update)) != false;
        }
        public async Task<EmployeeGeneralDTO> GetEmployee(int id)
        {
            var emp = await _repo.GetAsync(id,"Department");
            if (emp != null)
            {
                return emp.AsDTO();
            }

            return null!;
        }

        public async Task<IEnumerable<EmployeeGeneralDTO>> GetAllEmployeesWithFilter(Expression<Func<Employee, bool>>? filter)
        {
            List<EmployeeGeneralDTO> dtoList = new List<EmployeeGeneralDTO>();
            var emplist =  await _repo.GetAllAsync(filter);
            foreach(var emp in emplist)
            {
                dtoList.Add(emp.AsDTO());
            }
            return dtoList;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _repo.DeleteAsync(id) != false;
        }

    }
}
