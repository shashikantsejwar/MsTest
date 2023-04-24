using Microsoft.AspNetCore.Mvc;
using MsTest.Model;
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

        [HttpGet("{empId}")]
        public IActionResult GetAllEmployeeById(int empId)
        {
            var (status, employee) = _employeeService.GetById(empId);
            if (status == "Success") return Ok(employee);
            else return BadRequest(status);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            var result = _employeeService.Add(employee);
            return Ok(result); 
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            var result = _employeeService.Update(employee);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int empId)
        {
            _employeeService.Delete(empId);
            return Ok();

        }

        [HttpGet("averageSalary/{departmentName}")]
        public IActionResult GetAverageSalaryByDepartmentName(string departmentName)
        {
            var (status, averageValue) = _employeeService.GetAverageSalaryByDeparmentName(departmentName);

            if (status == "Success") return Ok(averageValue);
            else return BadRequest(status);
        }

        [HttpGet("departmentCount")]
        public IActionResult GetEmployeeCountByDepartment()
        {
            var (status, departmentCount) = _employeeService.GetEmployeeCountByDepartment();

            if (status == "Success") return Ok(departmentCount);
            else return BadRequest(status);
        }

        [HttpGet("getProducts/{productCategory}")]
        public async Task<IActionResult> GetProductByCategory(string productCategory)
        {
            var result = await _employeeService.GetProductByCategory(productCategory);
            return Ok(result);
        }


    }
}
