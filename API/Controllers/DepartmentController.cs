using DataAccess.DTOs.Department;
using Business.Services;
using DataAccess.Models;
using DataAccess.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentManager _departmentmanager;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(DepartmentManager departmentmanager, ILogger<DepartmentController> logger)
        {
            _logger = logger;
            _departmentmanager = departmentmanager;
        }

        [HttpPost("Add-Department/")]
        public async Task<IActionResult> AddDepartment(DepartmentGeneralDTO DeptDto)
        {
            return await _departmentmanager.AddDept(DeptDto) == false
                ? BadRequest() : Ok();
        }
        [HttpPut("Update-Department/")]
        public async Task<IActionResult> UpdateDept(DepartmentGeneralDTO dto)
        {
            return await _departmentmanager.UpdateDept(dto) == false
                ? BadRequest() : Ok();
        }
        [HttpDelete("Delete-Department/{id}/")]
        public async Task<IActionResult> DeleteDept(int id)
        {
            return await _departmentmanager.DeleteDept(id) == false?
                BadRequest(id) : Ok();
        }

        [HttpGet("Get-DepartmentbyId/{id}/")]
        public async Task<IActionResult> GetDeptById(int id)
        {
            return Ok(await _departmentmanager.GetDept(id));
        }

        [HttpGet("Get-All-Departmets/")]
        public async Task<IActionResult> GetAllDepts()
        {
            return Ok(await _departmentmanager.GetAllDepts());
        }
    }
}
