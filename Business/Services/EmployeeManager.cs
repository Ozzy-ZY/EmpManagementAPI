using Business.DTOs.Employee;
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
    public class EmployeeManager
    {
        private readonly IRepo<Employee> _repo;

        public EmployeeManager(IRepo<Employee> repo) {
            _repo = repo;
        }
        public async Task<bool> AddEmployee(EmployeeAddDTO dto)
        {
            Employee emp = new Employee() {
                FName = dto.FirstName,
                LName = dto.LastName,
                Title = dto.Title,
                Phone = dto.Phone,
                Email = dto.Email,
                DepartmentId = dto.DepartmentId,
                City = "NewYork",
                Salary = dto.Salary};
            return await _repo.AddAsync(emp) != false;
        }
        public async Task<bool> UpdateEmployee(EmployeeUpdateDTO dto)
        {
            Employee emp = new Employee()
            {
                Id = dto.Id,
                FName = dto.FirstName,
                LName = dto.LastName,
                Title = dto.Title,
                Phone = dto.Phone,
                Email = dto.Email,
                DepartmentId = dto.DepartmentId,
                City = "NewYork",
                Salary = dto.Salary,
                ModifiedAt = DateTime.Now,
            };
            return await _repo.UpdateAsync(emp) != false;
        }
        public async Task<EmployeeGetDTO> GetEmployee(int id)
        {
            var emp = await _repo.GetAsync(id,"Department");
            if (emp != null)
            {
                return new EmployeeGetDTO($"{emp.FName} {emp.LName}", emp.Title, emp.DepartmentId);
            }

            return null!;
        }

        public async Task<IEnumerable<EmployeeGetAllDTO>> GetAllEmployeesWithFilter(Expression<Func<Employee, bool>>? filter)
        {
            List<EmployeeGetAllDTO> dtoList = new List<EmployeeGetAllDTO>();
            var emplist =  await _repo.GetAllAsync(filter);
            foreach(var emp in emplist)
            {
                dtoList.Add(new EmployeeGetAllDTO($"{emp.FName} {emp.LName}", emp.Title, emp.Department.Name));
            }
            return dtoList;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _repo.DeleteAsync(id) != false;
        }

    }
}
