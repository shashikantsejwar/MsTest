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

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.AllEmployees();
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
            if (department != null && department.Count() > 0)
            {
                return ("Success", department);
            }
            return ("Departments Not found", null);
        }

        public (string status, IEnumerable<Location> departmentLocations) GetDepartmentLocations(string name)
        {
            var DepartmentLocations = _employeeRepository.AllEmployees().Where(x => x.Department.Name.ToLower() == name.ToLower())
                .Select(x => x)
                .SelectMany(y => y.Locations).Distinct();

            if (DepartmentLocations != null)
            {
                return ("Success", DepartmentLocations);
            }
            return ("Department Not found", null);
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            var client = _httpClient.CreateClient();
            var response = await client.GetStringAsync($"https://fakestoreapi.com/products/category/{categoryName}");

            var result = JsonSerializer.Deserialize<IEnumerable<Product>>(response);

            return result;
        }


    }
}
