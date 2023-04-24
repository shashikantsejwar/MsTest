using MsTest.Model;
using MsTest.Model.Models;

namespace MsTest.Services.Interfaces
{
    public interface IEmployeeService
    {
        public (string status, Employee? employee) GetById(int id);
        public IEnumerable<Employee> GetAll();
        public (string status, decimal averageValue) GetAverageSalaryByDeparmentName(string name);

        public (string status, IEnumerable<DepartmentCount> departmentCount) GetEmployeeCountByDepartment();

        public (string status, IEnumerable<Location> departmentLocations) GetDepartmentLocations(string name);
        public Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
    }
}
