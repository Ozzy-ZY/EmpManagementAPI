using DataAccess.DTOs.Employee;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeManager _employeeManager;
        private readonly ILogger<EmployeesController> _logger;
        public EmployeesController(EmployeeManager employeeManager, ILogger<EmployeesController> logger)
        {
            _employeeManager = employeeManager;
            _logger = logger;
        }

        [HttpPost("Add-Employee/")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeGeneralDTO empDto)
        {
            return await _employeeManager.AddEmployee(empDto) == false
                ? BadRequest() : Ok();
        }

        [HttpPut("Update-Employee/")]
        public async Task<IActionResult> UpdateEmp([FromBody] EmployeeGeneralDTO dto)
        {
            return await _employeeManager.UpdateEmployee(dto) == false
                ? NotFound() : Ok();
        }

        [HttpDelete("Delete-Employee/{id}/")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return await _employeeManager.DeleteEmployee(id) == false
                ? Ok() : NotFound();
        }

        [HttpGet("Get-Employee/{id}/")]
        public async Task<IActionResult> GetById(int id) 
        {
            return Ok(await _employeeManager.GetEmployee(id));
        }

        [Authorize]
        [HttpGet("Get-All-Employees/")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeManager.GetAllEmployeesWithFilter());
        }


    }
}
