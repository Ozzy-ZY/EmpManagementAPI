using DataAccess.DTOs.Employee;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("GetEmployee/{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            return Ok(await _employeeManager.GetEmployee(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeManager.GetAllEmployeesWithFilter());
        }
        [HttpPost("AddEmployee/")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeGeneralDTO empDto)
        {
            if(await _employeeManager.AddEmployee(empDto))
                return Ok();
            return BadRequest();
        }

    }
}
