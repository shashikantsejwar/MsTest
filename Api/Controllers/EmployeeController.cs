using Microsoft.AspNetCore.Mvc;
using MsTest.Services.Interfaces;

namespace MsTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var result = _employeeService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllEmployeeById(int empId)
        {
            var result = _employeeService.GetById(empId);
            if (result.status == "Success") return Ok(result.employee);
            else return BadRequest(result.status);
        }

        [HttpGet("averageSalary/{departmentName}")]
        public IActionResult GetAverageSalaryByDepartmentName(string departmentName)
        {
            var result = _employeeService.GetAverageSalaryByDeparmentName(departmentName);

            if (result.status == "Success") return Ok(result.averageValue);
            else return BadRequest(result.status);
        }

        [HttpGet("departmentCount")]
        public IActionResult GetEmployeeCountByDepartment()
        {
            var result = _employeeService.GetEmployeeCountByDepartment();

            if (result.status == "Success") return Ok(result.departmentCount);
            else return BadRequest(result.status);
        }

        [HttpGet("departmentLocations/{departmentName}")]
        public IActionResult GetDepartmentLocations(string departmentName)
        {
            var result = _employeeService.GetDepartmentLocations(departmentName);

            if (result.status == "Success") return Ok(result.departmentLocations);
            else return BadRequest(result.status);
        }

        [HttpGet("getProducts/{productCategory}")]
        public async Task<IActionResult> GetProductByCategory(string productCategory)
        {
            var result = await _employeeService.GetProductByCategory(productCategory);
            return Ok(result);
        }


    }
}
