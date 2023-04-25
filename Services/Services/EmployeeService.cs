using MsTest.Model;
using MsTest.Model.Models;
using MsTest.Services.Interfaces;
using Repository.Interfaces;
using System.Text.Json;

namespace MsTest.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IHttpClientFactory httpClient, IEmployeeRepository employeeRepository)
        {
            _httpClient = httpClient;
            _employeeRepository = employeeRepository;
        }

        public (string status, Employee? employee) GetById(int id)
        {
            var employee = _employeeRepository.AllEmployees().FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return ("Not Found", employee);
            }
            return ("Success", employee);
        }

        public (string status, IEnumerable<Employee> employees) GetAll()
        {
            var employees = _employeeRepository.AllEmployees();
            if (employees.Any())
            {
                return ("Success", employees);
            }
            else
            {
                return ("No Employees Exist", employees);
            }
        }

        public (string status, decimal averageValue) GetAverageSalaryByDeparmentName(string name)
        {
            var department = _employeeRepository.AllEmployees().Where(x => x.Department.Name.ToLower() == name.ToLower()).ToList();
            if (department != null && department.Count > 0)
            {
                return ("Success", department.Average(y => y.Salary));
            }
            return ("Department Not found", 0);
        }

        public (string status, IEnumerable<DepartmentCount> departmentCount) GetEmployeeCountByDepartment()
        {
            var department = _employeeRepository.AllEmployees().GroupBy(x => x.Department.Name)
                .Select(x => new DepartmentCount { DepartmentName = x.Key, EmployeeCount = x.Count() });
            if (department != null && department.Any())
            {
                return ("Success", department);
            }
            return ("Departments Not found", null);
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            var client = _httpClient.CreateClient();
            var response = await client.GetStringAsync($"https://fakestoreapi.com/products/category/{categoryName}");

            var result = JsonSerializer.Deserialize<IEnumerable<Product>>(response);

            return result;
        }

        public Employee Add(Employee employee)
        {
            return _employeeRepository.AddEmployee(employee);
        }

        public Employee Update(Employee employee)
        {
            return _employeeRepository.Update(employee);
        }

        public void Delete(int employeeId)
        {
            var employee = _employeeRepository.AllEmployees().Where(x => x.Id == employeeId).FirstOrDefault();
            if (employee != null)
            {
                _employeeRepository.Delete(employee);
            }
        }
    }
}
