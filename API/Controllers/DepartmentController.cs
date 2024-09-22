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
        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentGeneralDTO DeptDto)
        {
            return await _departmentmanager.AddDept(DeptDto) == false
                ? BadRequest() : Ok();
        }
    }
}
